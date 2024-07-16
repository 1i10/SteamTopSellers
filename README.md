# Скрапинг страницы лидеров продаж в Steam

## Навигация
+ [Краткое описание](#краткое-описание)
+ [Структура репозитория](#структура-репозитория)
+ [Предварительные настройки](#предварительные-настройки)
+ [Пример](#пример)



## Краткое описание

Проект разработан на языке C# в IDE Microsoft Visual Studio 2022 под ОС Windows.  
Консольное приложение позволяет пользователю извлекать [список лидеров продаж игр на платформе Steam](https://store.steampowered.com/charts/topselling/).  
Основные возможности приложения включают:  

* Извлечение списка лидеров продаж с указанием их позиций, названий и цен;
* Использование [Selenium WebDriver](https://www.zenrows.com/blog/web-scraping-c-sharp#headless-browser-scraping) для скрапинга данных с веб-страницы.  
  
По дефолту извлекается топ-10 игр для RU-региона (но можно изменить).  

## Структура репозитория

* [*Program.cs*](https://github.com/1i10/SteamTopSellers/blob/main/Program.cs) - исполняемый файл программы для получения лидеров продаж в Steam.  
* [*SteamScraper.cs*](https://github.com/1i10/SteamTopSellers/blob/main/SteamScraper.cs) - класс, реализующий функциональность скрапинга лидеров продаж с веб-страницы Steam.  
* [*TopSeller.cs*](https://github.com/1i10/SteamTopSellers/blob/main/TopSeller.cs) - класс, представляющий данные об лидере продаж(позиция, название, цена).  
* [*SteamTopSellers.sln*](https://github.com/1i10/SteamTopSellers/blob/main/SteamTopSellers.sln) - файл решения для Visual Studio.  
  
*Методы классов задокументированы в коде программы.*

## Предварительные настройки

1. Загрузите проект на локальную машину, воспользовавшись командой *git clone*.

2. Откройте решение **SteamTopSellers.sln** в Microsoft Visual Studio.

3. Убедитесь, что на вашей системе установлен Google Chrome и ChromeDriver.

4. Установите Selenium WebDriver для проекта. Это можно сделать через NuGet Package Manager в Visual Studio:

```sh
dotnet add package Selenium.WebDriver
dotnet add package Selenium.WebDriver.ChromeDriver
```
   
  
## Пример

**Топ-10 лидеров продаж за 16.07.2024 12:22:**  
![Пример1](https://github.com/1i10/SteamTopSellers/blob/master/example.png)  
