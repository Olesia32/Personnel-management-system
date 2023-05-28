# Система управління персоналом

Це програма Windows Forms, яка забезпечує можливість керування працівниками компанії. Вона забезпечує функціональність для створення, зміни та видалення працівників, формування залежностей "керівник-підлеглий", збереження та завантаження даних про них із файлів. Також програма дає можливість обчислювати різні статистичні дані, будувати емпіричні функції розподілу та вести журнал операцій.

## Особливості

- **MainForm**: головна форма програми, яка відображає список співробітників у двох елементах керування DataGridView, одному для лідерів, а іншому для програмістів. Вона містить кнопки для створення, зміни та видалення співробітників, перегляду журналу операцій, відображення графічних даних. Для кожного керівника можна відобразити його підлеглих, а для кодного працівника - керівника.

- **CreateForm**: діалогова форма, яка дозволяє користувачеві створити нового керівника або програміста. Вона запитує необхідну інформацію та додає нового співробітника до відповідного елемента керування DataGridView.

- **ChangeForm**: діалогова форма, яка дозволяє користувачеві змінювати інформацію про співробітника. Вона попередньо заповнює інформацію про співробітника та дозволяє користувачеві оновлювати будь-які поля. Якщо співробітник є програмістом, доступна можливість приначити йому іншого керівника.

- **LoginForm**: форма, яка запитує пароль для доступу до системи. У разі введення правильного пароля відкривається головна форма.

- **ChartForm**: діалогова форма, яка дозволяє запустити та відобразити у вигляді графіків, обчислення емпіричної функції розподілу зарплати окремо для керівників та працівників. Обчислення проходять у окремих потоках.

- **Меню**: програма надає меню з опціями для відкриття та збереження файлів, друку, копіювання. Відкрити та завантажити можна файли різних форматів, зокрема: текстові файли, двійкові файли, файли XML і файли JSON.

- **Управління даними**: програма використовує клас `Personal` для керування даними співробітників. Він надає методи читання даних із файлів, запису даних у файли, додавання нових співробітників, видалення співробітників, оновлення інформації про співробітників та багато інших функцій.

- **Журнал**: програма веде журнал операцій, виконаних з даними співробітників. Журнал автоматично зберігається при завершенні роботи.

## Використання

1. Коли програма запускається, вона завантажує дані про співробітника з файлу за замовчуванням і відображає їх в елементах керування DataGridView.

2. Скористайтеся кнопкою «Створити», щоб створити нового співробітника. Відкривається діалогове вікно «CreateForm», де можна ввести інформацію про співробітника. Виберіть, чи є співробітник лідером чи програмістом, і надайте необхідні дані. Натисніть «Продовжити», щоб створити співробітника.

3. Використовуйте кнопку «Змінити», щоб змінити інформацію про співробітника. Виберіть співробітника з елемента керування DataGridView та натисніть «Змінити». Він відкриває діалогове вікно «ChangeForm», де можна оновити інформацію про співробітника. Внесіть необхідні зміни та натисніть «Продовжити», щоб зберегти зміни.

4. Використовуйте кнопку «Видалити», щоб видалити співробітника. Виберіть співробітника з елемента керування DataGridView та натисніть «Видалити». Підтвердьте видалення в запиті.

5. Скористайтеся кнопкою «Зберегти» або опцією «Зберегти як» у меню, щоб зберегти дані про співробітника у файл. Виберіть потрібний формат файлу та розташування. Програма підтримує текстові файли, двійкові файли, файли XML і файли JSON.

6. Використовуйте опцію «Відкрити» в меню, щоб завантажити дані про співробітника з файлу. Виберіть файл для відкриття. Програма спробує завантажити дані з файлу та відобразити їх в елементах керування DataGridView.

7. Скористайтесь кнопкою "Журнал операцій", щоб відобразити інформацію про ваші дії, повідомлення від відділу кадрів та отримати можливість провести обчислення.

8. Скористайтесь кнопкою "Графічні дані", щоб відобразити емпіричні функції розподілу зарплат керівників та працівників.

9. Використовуйте кнопку "Показати керівника\підлеглих", щоб отримати інформацію про залежності "керівник-підлеглий".

## Вимоги

- Операційна система Microsoft Windows
- .NET Framework
- Visual Studio (або інша сумісна IDE) для компіляції та запуску програми
