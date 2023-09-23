from flask import Flask # из библиотеки flask импортирвать объект flask
 
app = Flask(__name__)
 
@app.route('/') #get по умолчанию
def main():
    return '<h1>Hello world!</h1>'
 

@app.route('/info') # Декоратор - распределение между обработчиками событий
def info(): # Функция
    return '<h1>Меня создала компания GeekBrains</h1>'


@app.route('/summa/<x>/<y>') # Передача переменных x, y
def summa(x, y): # Передача параметров x, y в функцию summa(в виде строк)
    return f'<h1>{x} + {y} = {int(x) + int(y)}</h1>' # http://127.0.0.1:5000/summa/12/15, int переводит строки в числа, f - $ в c#


if __name__ == '__main__':
    app.run()