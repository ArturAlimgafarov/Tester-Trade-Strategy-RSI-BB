from urllib.parse import urlencode
from urllib.request import urlopen, Request
from datetime import datetime
import json
import time
import numpy as np
import talib

def strategy_analysis(data):
    bb = talib.BBANDS(np.array(data['close'], dtype=np.float64), timeperiod=20)
    rsi = talib.RSI(np.array(data['close'], dtype=np.float64), timeperiod=4)

    stats = []
    sell = 0
    buy = 0
    profit = 0
    loss = 0
    for i, v in enumerate(rsi):
        if data['close'][i] > bb[0][i] and v > 80:
            sell += 1
            if i != len(rsi) - 1:
                if data['close'][i + 1] < data['close'][i]:
                    profit += 1
                    stats.append(1)
                else:
                    loss += 1
                    stats.append(0)
        if data['close'][i] < bb[2][i] and v < 20:
            buy += 1
            if i != len(rsi) - 1:
                if data['close'][i + 1] > data['close'][i]:
                    profit += 1
                    stats.append(1)
                else:
                    loss += 1
                    stats.append(0)
    count = len(data['close']) - 20
    freq = round(count / (buy + sell))
    p = round(100 * loss / profit, 2)
    return count, buy, sell, profit, loss, freq, p

input_file = open('data.json')
output_file = open('analysis_data.txt', 'w')

input_data = json.load(input_file)

start_date_str = input_data['StartDate']
end_date_str = input_data['EndDate']
timeframe_code = input_data['TimeFrameCode']
tickers = input_data['TickersData']

# скачивание данных с ФИНАМа
finam_url = 'http://export.finam.ru/'
market = 5
start_date = datetime.strptime(start_date_str, '%d.%m.%Y').date()
start_date_rev = datetime.strptime(start_date_str, '%d.%m.%Y').strftime('%Y%m%d')
end_date = datetime.strptime(end_date_str, '%d.%m.%Y').date()
end_date_rev=datetime.strptime(end_date_str, '%d.%m.%Y').strftime('%Y%m%d')

if len(tickers) == 1:

    for ticker in tickers:
        params = urlencode([
                            ('market', market), # рынок
                            ('em', tickers[ticker]), # цифровой код
                            ('code', ticker), # тикер акции
                            ('apply', 0),
                            ('df', start_date.day), # начальная дата, номер дня (1-31)
                            ('mf', start_date.month - 1), # начальная дата, номер месяца (0-11)
                            ('yf', start_date.year), # начальная дата, год
                            ('from', start_date), # начальная дата полностью
                            ('dt', end_date.day), # конечная дата, номер дня
                            ('mt', end_date.month - 1), # конечная дата, номер месяца
                            ('yt', end_date.year), # конечная дата, год
                            ('to', end_date), # конечная дата
                            ('p', timeframe_code), # таймфрейм
                            ('f', 'qoutes_data'), # имя сформированного файла
                            ('e', '.csv'), # расширение сформированного файла
                            ('cn', ticker), # тикер акции
                            ('dtf', 1), # формат даты
                            ('tmf', 1), # формат времени
                            ('MSOR', 0), # время свечи (0 - open; 1 - close)
                            ('mstime', 'on'), # Московское время
                            ('mstimever', 1), # коррекция часового пояса
                            ('sep', 1), # разделитель полей	(1 - запятая, 2 - точка, 3 - точка с запятой, 4 - табуляция, 5 - пробел)
                            ('sep2', 1), # разделитель разрядов
                            ('datf', 5), # формат записи в файл
                            ('at', 0)]) # включать заголовок (0 - нет, 1 - да)

        url = finam_url + ticker + '_' + start_date_rev + '_' + end_date_rev + '.csv?' + params
        req = Request(url, headers={'User-Agent': 'XYZ/3.0'})
        txt_data = urlopen(req).readlines()

        data = {
            'dt': [],
            'close': [],
        }

        for line in txt_data:
            s = line.strip().decode('utf-8').split(',')
            data['dt'].append((s[0], s[1]))
            data['close'].append(float(s[5]))

        count, buy, sell, profit, loss, freq, p = strategy_analysis(data)

        analysis_text = f'{ticker} ({start_date_str} - {end_date_str}) \n\n' \
                        f'Количество свеч:\t\t{count}\n' \
                        f'Сигналы ВВЕРХ (BUY):\t{buy}\n' \
                        f'Сигналы ВНИЗ (SELL):\t{sell}\n' \
                        f'Кол-во сделок в ПЛЮС:\t{profit}\n' \
                        f'Кол-во сделок в МИНУС:\t{loss}\n' \
                        f'Частота сигналов:\t{freq} (свеч)\n' \
                        f'Критический процент:\t{p}%\n'

        quotes_file = open('quotes_data.txt', 'w')
        for line in txt_data:
            quotes_file.write(line.strip().decode('utf-8') + '\n')
        quotes_file.close()

        output_file.write(analysis_text)
        output_file.close()
else:

    tickers_out_list = []
    undefined_data = []
    for ticker in tickers:
        try:
            params = urlencode([
                                ('market', market), # рынок
                                ('em', tickers[ticker]), # цифровой код
                                ('code', ticker), # тикер акции
                                ('apply', 0),
                                ('df', start_date.day), # начальная дата, номер дня (1-31)
                                ('mf', start_date.month - 1), # начальная дата, номер месяца (0-11)
                                ('yf', start_date.year), # начальная дата, год
                                ('from', start_date), # начальная дата полностью
                                ('dt', end_date.day), # конечная дата, номер дня
                                ('mt', end_date.month - 1), # конечная дата, номер месяца
                                ('yt', end_date.year), # конечная дата, год
                                ('to', end_date), # конечная дата
                                ('p', timeframe_code), # таймфрейм
                                ('f', 'qoutes_data'), # имя сформированного файла
                                ('e', '.csv'), # расширение сформированного файла
                                ('cn', ticker), # тикер акции
                                ('dtf', 1), # формат даты
                                ('tmf', 1), # формат времени
                                ('MSOR', 0), # время свечи (0 - open; 1 - close)
                                ('mstime', 'on'), # Московское время
                                ('mstimever', 1), # коррекция часового пояса
                                ('sep', 1), # разделитель полей	(1 - запятая, 2 - точка, 3 - точка с запятой, 4 - табуляция, 5 - пробел)
                                ('sep2', 1), # разделитель разрядов
                                ('datf', 5), # формат записи в файл
                                ('at', 0)]) # включать заголовок (0 - нет, 1 - да)

            url = finam_url + ticker + '_' + start_date_rev + '_' + end_date_rev + '.csv?' + params
            req = Request(url, headers={'User-Agent': 'XYZ/3.0'})
            txt_data = urlopen(req).readlines()

            data = {
                'dt': [],
                'close': [],
            }

            for line in txt_data:
                s = line.strip().decode('utf-8').split(',')
                data['dt'].append((s[0], s[1]))
                data['close'].append(float(s[5]))

            _, _, _, _, _, freq, p = strategy_analysis(data)
            tickers_out_list.append((ticker, p, freq))
        except:
            undefined_data.append((ticker, np.NaN, np.NaN))

    tickers_out_list.sort(key=lambda item: item[1])

    for und_item in undefined_data:
        tickers_out_list.append(und_item)

    analysis_text = f'{start_date_str} - {end_date_str}\n' \
                    f'Название\tКрит.процент\tЧастота\n\n'
    for item in tickers_out_list:
        analysis_text += f'{item[0]}\t\t{item[1]}\t\t{item[2]}\n'

    output_file.write(analysis_text)
    output_file.close()