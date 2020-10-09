# xt_net_web

************** ЗАДАНИЯ **************
------ TASK 11 | DATABASES ------
11.1.	DATABASE
Реализовать базу данных Microsoft SQL Server для хранения данных приложения «Пользователи и награды» из задания 10. База данных должна быть приведена к третьей нормальной форме.
Желательно (но не обязательно) написать хранимые процедуры для операций над данными.
11.2.	SQL DAL
Написать реализацию DAL для приложения, основанную на БД из предыдущего задания. В качестве технологии доступа использовать присоединённую модель ADO.NET.
•	Ранее написанная архитектура не должна подвергаться изменениям;
•	Допускается изменение ранее написанного кода с целью исправления ошибок;
•	Работоспособность предыдущей версии DAL не должна пострадать;
•	Выбор используемой реализации DAL определяется на основании значения параметра в файле конфигурации.

------ TASK 10 | ASP.NET WEB PAGES ------
10.1.	WEB UI
Добавить к приложению «Пользователи и награды» из задания 6 визуальный интерфейс на основе ASP.NET Web Pages. 
Приложение должно позволять выполнять все те же действия, что и консольная версия.
•	Ранее написанная архитектура не должна подвергаться изменениям;
•	Допускается изменение ранее написанного кода с целью исправления ошибок;
•	Работоспособность консольного приложения не должна пострадать;
•	Web-приложение должно корректно работать в двух последних версиях Chrome и Edge 13.
10.2.	CRUD APPLICATION
Расширить функциональность приложения до CRUD-полной: добавление, редактирование, удаление и просмотр перечня его сущностей.
•	Реализация нового функционала для консольного приложения не требуется, но предыдущая функциональность не должна пострадать;
•	При удалении награды, выданной кому-либо, пользователю должен предоставляться выбор: удалить эту награду у всех пользователей или отказаться от запрошенной операции.
10.3.	IMAGES
Реализовать возможность добавления к пользователям и наградам изображений, загружаемых пользователем самостоятельно. Предусмотреть корректное масштабирование загружаемых изображений, а также картинку-заглушку в случае отсутствия изображения.
10.4.	SECURITY
Добавить в приложение ролевую модель. Предусмотреть форму входа в систему (в заголовке любой страницы) и окно регистрации нового пользователя. Права групп:
•	Анонимные пользователи (гости) — просмотр перечня «пользователей» (из приложения, а не тех, что зарегистрировались) без указания наград;
•	Зарегистрированные пользователи — просмотр перечня «пользователей» и вручённых им наград;
•	Администраторы — просмотр и редактирование перечня «пользователей» и вручённых им наград, просмотр и редактирование перечня наград, назначение и снятие административных прав с зарегистрированных пользователей (хотя бы один администратор должен быть изначально).
Модуль аутентификации должен быть написан с возможностью последующей замены его на другую реализацию.

------ TASK 09 | JAVASCRIPT BASICS ------
9.1.	CHAR REMOVER
Написать функцию, на вход которой приходит строка, состоящая из нескольких слов. Слова разделены пробельными символами (пробел, табуляция) и знаками препинания (?!:;,.).  Нужно вернуть строку, в которой будут удалены все символы, повторяющиеся хоть в одном из слов более одного раза.
Пример:
Ввод: У попа была собака
Результат: У о был собк
Примечание: Не использовать регулярные выражения.
9.2.	MATH CALCULATOR
Написать функцию для подсчёта результата выражения. На вход приходит строка с арифметическим выражением. Внутри выражения записываются вещественные числа (в качестве разделителя целой и дробной части используется точка), разделённые математическими операторами (+ − * /). Между числом и оператором может стоять пробел. В конце строки стоит знак «равно».
Пример:
3.5 +4*10-5.3 /5 = 
Результат выражения вычисляется последовательно. Приоритет операций не учитывается. Результат выводить с точностью до 2 знаков после запятой.
Примечания:
	1.	Для вычисления нельзя пользоваться функцией eval().
	2.	Для разбора выражения использовать регулярные выражения.
9.3.	BUTTERFLY CONTROL
     Создать страницу со следующим набором элементов (интерфейс приблизителен):
При нажатии кнопок   и  выделенные элементы из одного списка перекидываются в другой. При этом выделение с них снимается, и они добавляются в конец списка. Если ни один из элементов не выделен, выводится соответствующее сообщение.
При нажатии кнопок  и   все элементы из одного списка перекидываются в другой.
Примечание:	Предусмотреть возможность нахождения на одной странице нескольких таких групп элементов со схожим функционалом.
9.4.	SIMPLE GALLERY
Создать сайт, позволяющий просматривать несколько страниц последовательно друг за другом. 
Содержимое страниц значения не имеет.
Каждая страница показывается в течение определённого времени, по истечение которого происходит переход на следующую страницу. Последовательность страниц жёстко задана. На странице должен быть размещён обратный отсчёт до перехода на следующую страницу. 
При достижении последней страницы выводится запрос о повторении пролистывания страниц или завершении работы. Если выбрано пролистывание, то пользователь перенаправляется на первую страницу, если же выбрано завершение пролистывания, то окно браузера закрывается.
На каждой странице пользователь может:
1.	Перейти на предыдущую страницу при нажатии на определённую кнопку.
2.	Приостановить обратный отсчёт и повторно запустить его.

------ TASK 08 | WEB BASICS ------
8.1.	LIST MENU
Сверстайте меню, показанное на рисунке ниже, на HTML5 с помощью тегов <ul> и <li>. Ширина меню должна быть фиксирована и равна 200 px. 
8.2.	REGISTRATION FORM
Сверстайте форму регистрации, показанную на рисунке ниже. Ширина формы и её полей должна быть фиксирована.
8.3.	DROPDOWN MENU
Сверстайте ниспадающее меню, показанное на рисунках ниже.
8.4.	POINTING BLOCK
Сверстайте страницу как показано на рисунке ниже. Ширина блока резиновая и меняется в зависимости от размеров окна браузера. Указатель всегда располагается посередине блока, размеры указателя фиксированы.
8.5.	THREE COLUMN BLOCK
Создайте страницу, показанную на рис. 1. Ширина блока фиксирована. Постарайтесь обойтись одним изображением (рис. 2), добавляя его как фоновый рисунок.
8.6.	EQUALIZER
Сверстайте страницу как показано на рисунке ниже. Ориентируйтесь на последние версии браузеров, использовать стилевые префиксы не обязательно.
8.7.	HEADER
Сверстайте на HTML5 страницу, показанную ниже.
8.8.	ARTICLE
Сверстайте страницу как показано на рисунке ниже, которая корректно должна отображаться во всех современных браузерах. Обратите внимание на небольшой градиент в блоке, светлую рамку вокруг и скругление уголков снизу.
8.9.	STEP COUNTER
Сделайте указатель шагов, показанный ниже на рисунке. Шаги должны корректно отображаться в браузерах Opera 12+, Firefox 6+, Chrome 12+. Для IE достаточно сделать горизонтальные прямоугольники без стрелок и градиентов. Все элементы должны отображаться правильно независимо от выбранного текущего шага.
8.10.	* VK
Сверстайте страницу — копию страницы «Настройки» социальной сети «ВКонтакте» (https://vk.com/settings).


------ TASK 07 | REGULAR EXPRESSIONS ------
7.1. DATE EXISTANCE
Напишите программу, которая определяет, содержится ли во введенном с клавиатуры тексте дата
в формате dd-mm-yyyy.
Пример:
Введите текст, содержащий дату в формате dd-mm-yyyy: 2016 год наступит 01-01-2016
В тексте "2016 год наступит 01-01-2016" содержится дата.
7.2. HTML REPLACER
Напишите программу, которая заменяет все найденные в тексте теги HTML на знак подчёркивания.
Пример:
Введите текст: <b>Это</b> текст <i>с</i> <font color="red">HTML</font> кодами
Результат замены: _Это_ текст _с_ _HTML_ кодами
7.3. EMAIL FINDER
Напишите программу, которая находит и выводит на экран все содержащиеся во введённой с
клавиатуры текстовой строке адреса электронной почты. Учесть, что имя почтового ящика может
содержать буквы, цифры, точку, дефис и знак подчёркивания, причём первым и последним
символами могут быть только буквы или цифры. Для имён поддоменов действуют те же самые
правила, но точка и знак подчёркивания допустимыми не являются. Имя домена верхнего уровня
может состоять только из букв в количестве от 2 до 6.
Пример:
Введите строку: Иван: ivan@mail.ru, Петр: p_ivanov@mail.rol.ru
Найденные адреса электронной почты:
ivan@mail.ru
p_ivanov@mail.rol.ru
7.4. NUMBER VALIDATOR
Напишите программу, которая проверяет текстовую строку на соответствие её текста формату
вещественного числа и выводит формат, в котором это число записано:
	1. Число может быть записано в обычной нотации;
	2. Число может быть записано в научной нотации
(например, 127 = 1.27×102 = 1.27e2, -0.0055 = -5.5×10-3 = -5.5e-3);
	3. Строка может не соответствовать формату вещественного числа.
Пример 1:
Введите число: 5
Это число в обычной нотации
Пример 2:
Введите число: -2.5
Это число в обычной нотации
Пример 3:
Введите число: 5.75e-5
Это число в научной нотации
Пример 4:
Введите число: *
Это не число
7.5. TIME COUNTER
Напишите программу, которая определяет, сколько раз в тексте встречается время. Постарайтесь
учесть, что в сутках только 24 часа, а в часе — 60 минут.
Пример:
Введите текст: В 7:55 я встал, позавтракал и к 10:77 пошёл на работу.
Время в тексте присутствует 1 раз.

------ TASK 06 | DESIGN PATTERNS ------
6.1. USERS…
Реализовать приложение с консольным интерфейсом, позволяющее работать со списком
пользователей (User: Id, Name, DateOfBirth, Age): создавать и удалять их, а также просматривать
их перечень. В качестве архитектурного шаблона применить трёхслойную архитектуру. Записи
должны сохраняться на жёсткий диск. Для повышения производительности можно реализовать
кэширование.
Примечания:
	1. При реализации трёхслойной архитектуры использовать слабое связывание (через
отдельную сборку с интерфейсами).
	2. Если для какого-либо слоя имеется несколько равноправных реализаций (например,
DAL.TextFiles и DAL.Memory), выбор конкретной реализации должен осуществляться на
основании записи в файле конфигурации.

6.2. … AND AWARDS
Дополнить приложение из задания 6.1 сущностью «Награда» (Award: Id, Title) и реализовать
соответствующие механизмы для добавления и просмотра перечня наград. Между пользователями
и наградами должна быть реализована связь многие-ко-многим (у каждого пользователя может
быть несколько наград, а наградой, соответственно, может быть награждено сколько угодно
пользователей). При отображении списка пользователей дополните каждого из них перечнем
наград, которыми он был награждён. Подумайте, как лучше организовать хранение этих данных в
файле.

------ TASK 05 | FILES ------
5.1.BACKUP SYSTEM 
Дана папка, которая является хранилищем файлов. Для всех текстовых файлов (*.txt), находящихся в этой папке или вложенных подпапках,реализовать сохранение истории изменений с возможностью отката состояния к любому моменту.Принцип работы программы:
	1.При запуске программа спрашивает пользователя, какой из режимов он хочет включить: наблюденияили отката изменений. Как вариант, можно использовать ключи командной строки.
	2.При выборе режима наблюдения все происходящие с текстовыми файлами изменения логируются до момента закрытия программы. Как вариант, можно создавать на диске в отдельной папке копии файлов по состоянию на момент изменения.
	3.При выборе режима отката изменений пользователь вводит дату и время, на которые должен быть осуществлён откат, после чего все текстовые файлы в папке должны принять вид, соответствующий указанному времени.
Возможностью изменения файлов в момент, когда программа не находится в режиме отслеживания изменений,пренебречь

------ TASK 04 | DELEGATES AND EXTENSIONS ------
4.1.	CUSTOM SORT
Написать метод, реализующий упорядочивание массива произвольного типа. Принцип сравнения двух элементов должен передаваться в метод через делегат. Стандартные инструменты типа Array.Sort и IComparable не использовать.
4.2.	CUSTOM SORT DEMO
Продемонстрировать работу метода, упорядочив массив строк по возрастанию длины. Строки равной длины между собой упорядочивать в алфавитном порядке.
4.3.	SORTING UNIT
Написать модуль сортировки, включающий в себя:
	1.	Метод сортировки из задания 4.1;
	2.	Метод, позволяющий запустить в сортировку в отдельном потоке выполнения;
	3.	Событие, сигнализирующее о завершении сортировки.
Продемонстрировать работу модуля в многопоточном режиме.
4.4.	NUMBER ARRAY SUM
Расширить массивы чисел методом, позволяющим найти их сумму.
4.5.	TO INT OR NOT TO INT?
Расширить строку методом, определяющим, является ли она положительным целым числом. Стандартные методы преобразования строки в число (Parse и т.п.) не использовать.


------ TASK 03 | COLLECTIONS ------
3.1.	LOST
В кругу стоят N человек, пронумерованных от 1 до N. При ведении счета по кругу вычёркивается каждый второй человек, пока не останется один. Составить программу, моделирующую процесс.
3.2.	WORD FREQUENCY
Задан английский текст. Выделить отдельные слова и для каждого посчитать частоту встречаемости. Слова, отличающиеся регистром, считать одинаковыми. В качестве разделителей считать пробел и точку.
3.3.	DYNAMIC ARRAY
На базе обычного массива (коллекции .NET не использовать) реализовать свой собственный класс DynamicArray<T>, представляющий собой динамический массив (массив с запасом) для хранения объектов произвольных типов. Класс должен содержать:
	1.	Конструктор без параметров (создаётся массив ёмкостью 8 элементов).
	2.	Конструктор с одним целочисленным параметром (создаётся массив указанной ёмкости).
	3.	Конструктор, который в качестве параметра принимает коллекцию, реализующую интерфейс IEnumerable<T>, создаёт массив нужного размера и копирует в него все элементы из коллекции.
	4.	Метод Add, добавляющий в конец массива один элемент. При нехватке места для добавления элемента, ёмкость массива должна удваиваться.
	5.	Метод AddRange, добавляющий в конец массива содержимое коллекции, реализующей интерфейс IEnumerable<T>. Обратите внимание, метод должен корректно учитывать число элементов в коллекции с тем, чтобы при необходимости расширения массива делать это только один раз вне зависимости от числа элементов в добавляемой коллекции.
	6.	Метод Remove, удаляющий из коллекции указанный элемент. Метод должен возвращать true, если удаление прошло успешно и false в противном случае. При удалении элементов реальная ёмкость массива не должна уменьшаться.
	7.	Метод Insert, позволяющий добавить элемент в произвольную позицию массива (обратите внимание, может потребоваться расширить массив). Метод должен возвращать true, если добавление прошло успешно и false в противном случае. При выходе за границу массива должно генерироваться исключение ArgumentOutOfRangeException.
	8.	Свойство Length — получение количества элементов. Не путать с ёмкостью (Capacity).
	9.	Свойство Capacity — получение ёмкости: длины внутреннего массива.
	10.	Методы, реализующие интерфейсы IEnumerable и IEnumerable<T>.
	11.	Индексатор, позволяющий работать с элементом с указанным номером. При выходе за границу массива должно генерироваться исключение ArgumentOutOfRangeException. 
3.4.	* DYNAMIC ARRAY (HARDCORE MODE)
Дополнить динамический массив из задания 3.3 следующим функционалом:
	1.	Доступ к элементам с конца при использовании отрицательного индекса (−1: последний, −2: предпоследний и т.д.).
	2.	Возможность ручного изменения значения Capacity с сохранением уцелевших данных (данные за пределами новой Capacity сохранять не нужно).
	3.	Реализовать интерфейс ICloneable для создания копии массива.
	4.	Добавить метод ToArray, возвращающий новый массив (обычный), содержащий все содержащиеся в текущем динамическом массиве объекты.
	5.	Создать новый класс: циклический динамический массив (CycledDynamicArray) на основе DynamicArray, отличающийся тем, что при использовании foreach после последнего элемента должен снова идти первый и так по кругу.

------ TASK 02 | OOP BASICS ------
-ENCAPSULATION-
2.1. ROUND
Написать класс Round, задающий круг с указанными координатами центра, радиусом, а также
свойствами, позволяющими узнать длину описанной окружности и площадь круга. Обеспечить
нахождение объекта в заведомо корректном состоянии. Написать программу, демонстрирующую
использование данного круга.
2.2. TRIANGLE
Написать класс Triangle, описывающий треугольник со сторонами a, b, c и позволяющий
осуществить расчёт его площади и периметра. Написать программу, демонстрирующую
использование данного треугольника.
2.3. USER
Написать класс User, описывающий человека (Фамилия, Имя, Отчество, Дата рождения, Возраст).
Написать программу, демонстрирующую использование этого класса.
2.4. MY STRING
Написать свой собственный класс MyString, описывающий строку как массив символов.
Реализовать для этого класса типовые операции (сравнение, конкатенация, поиск символов,
конвертация из/в массив символов, ...).
-INHERITANCE-
2.5. EMPLOYEE
На основе класса User (см. задание 2.3) создать класс Employee, описывающий сотрудника фирмы.
Дополнить класс свойствами «стаж работы» и «должность». Обеспечить нахождение класса в
заведомо корректном состоянии.
2.6. RING
Создать класс Ring, описывающий кольцо, заданное координатами центра, внешним и внутренним
радиусами, а также свойствами, позволяющими узнать площадь кольца и суммарную длину
внешней и внутренней окружностей. Обеспечить нахождение класса в заведомо корректном
состоянии.
-POLYMORPHISM-
2.7. VECTOR GRAPHICS EDITOR
Напишите заготовку для векторного графического редактора. Полная версия редактора должна
позволять создавать и выводить на экран такие фигуры как линия, окружность, прямоугольник,
круг, кольцо. Заготовка, для упрощения, должна представлять собой консольное приложение со
следующим функционалом:
• Создать фигуру выбранного типа по произвольным координатам;• Вывести фигуры на экран (для каждой фигуры вывести на консоль её тип и значения
параметров).
2.8. GAME
Создайте иерархию классов и пропишите ключевые методы для компьютерной игры (без
реализации функционала). Суть игры:
• Игрок может передвигаться по прямоугольному полю размером Width на Height;
• На поле располагаются бонусы (яблоко, вишня и т.д.), которые игрок может подобрать для
поднятия каких-либо характеристик;
• За игроком охотятся монстры (волки, медведи и т.д.), которые могут передвигаться по
карте по какому-либо алгоритму;
• На поле располагаются препятствия разных типов (камни, деревья и т.д.), которые игрок и
монстры должны обходить.
Цель игры — собрать все бонусы и не быть «съеденным» монстрами.

------ TASK 01 | C# BASICS ------
1.1. RECTANGLE
Написать программу, которая определяет площадь прямоугольника со сторонами a и b. Если пользователь вводит некорректные значения (отрицательные или ноль), должно выдаваться сообщение об ошибке. Возможность ввода пользователем строки вида «абвгд» или нецелых чисел игнорировать.
1.2. TRIANGLE
Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее «изображение», состоящее из N строк:
1.3. ANOTHER TRIANGLE
Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее «изображение», состоящее из N строк:
1.4. X-MAS TREE
Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее «изображение», состоящее из N треугольников:
1.5. SUM OF NUMBERS
Если выписать все натуральные числа меньше 10, кратные 3 или 5, то получим 3, 5, 6 и 9. Сумма этих чисел будет равна 23. Напишите программу, которая выводит на экран сумму всех чисел меньше 1000, кратных 3 или 5.
1.6. FONT ADJUSTMENT
Для форматирования текста надписи можно использовать различные начертания: полужирное, курсивное и подчёркнутое, а также их сочетания. Предложите способ хранения информации о форматировании текста надписи и напишите программу, которая позволяет устанавливать и изменять начертание:
--- TASK 01 | C# LANGUAGE ---
1.7. ARRAY PROCESSING
Написать программу, которая генерирует случайным образом элементы массива (число элементов в массиве и их тип определяются разработчиком), определяет для него максимальное и минимальное значения, сортирует массив и выводит полученный результат на экран.
Примечание: LINQ запросы и готовые функции языка (Sort, Max и т.д.) использовать в данном задании запрещается.
1.8. NO POSITIVE
Написать программу, которая заменяет все положительные элементы в трёхмерном массиве на нули. Число элементов в массиве и их тип определяются разработчиком.
1.9. NON-NEGATIVE SUM
Написать программу, которая определяет сумму неотрицательных элементов в одномерном массиве. Число элементов в массиве и их тип определяются разработчиком.
1.10. 2D ARRAY
Элемент двумерного массива считается стоящим на чётной позиции, если сумма номеров его позиций по обеим размерностям является чётным числом (например, [1,1] — чётная позиция, а [1,2] — нет). Определить сумму элементов массива, стоящих на чётных позициях.
--- TASK 01 | C# STRINGS ---
1.11. AVERAGE STRING LENGTH
Написать программу, которая определяет среднюю длину слова во введённой текстовой строке. Учесть, что символы пунктуации на длину слов влиять не должны. Регулярные выражения не использовать. И не пытайтесь прописать все символы-разделители ручками. Используйте стандартные методы классов String и Char.
1.12. CHAR DOUBLER
Написать программу, которая удваивает в первой введённой строке все символы, принадлежащие второй введённой строке.
Пример: 
Введите первую строку: написать программу, которая 
Введите вторую строку: описание 
Результирующая строка: ннааппииссаать ппроограамму, коотоораая

------ TASK 00 | C# BASICS ------
0.1. SEQUENCE 
Написать функцию, формирующую и возвращающую строку вида 1, 2, 3, … N (положительное число).
Значение N передаётся в функцию в качестве аргумента. Пример возвращаемого значения для N=7: 1, 2, 3, 4, 5, 6, 7
0.2. SIMPLE
Число считается простым, если его можно разделить без остатка только на единицу и на само себя (например, 7).
Необходимо написать функцию, определяющую, является ли заданное число N (положительное целое) простым.
Значение N передаётся в функцию в качестве аргумента.
0.3. SQUARE
Написать функцию, выводящую на экран квадрат из звёздочек со стороной равной N (положительное нечётное целое число). Центральная звёздочка должна отсутствовать.
Значение N передаётся в функцию в качестве аргумента.
На изображении приведён пример работы функции для N=7.
0.4. ARRAY (TASK 0.5) Написать программу, которая заполняет и сортирует многомерный массив. Постановка задачи: Пользователь вводит с клавиатуры число N (размерность массива), затем последовательно вводит N чисел – число элементов по каждой размерности. Программа должна: 1. Создать массив заданной размерности и указанной по размерностям длины. 2. Заполнить данный массив случайными числами из диапазона 0..100 (массив считаем целочисленным). 3. Вывести его на экран. 4. Отсортировать полученный массив. 5. Вывести на экран отсортированный массив.