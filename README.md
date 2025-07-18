# BiogenomTestTask
Web API построен по принципам чистой архитектуры, данный способ позволяет разделить компоненты программы на отдельные слои, что позволяет реализовать гибкую разработку, котороую в бедующем будет легко тестировать и масштабировать.
Далее описаны компоненты программы:
1)Controllers - Реализация API, принимает запросы и возвращает результат.
2)Data - Конфигурация EF Core.
3)DataTransfer - Регулирует то что вернется пользователь.
4)Interface - Шаблоны для сервисов, репозиториев.
5)Model - Описывает сущности БД.
6)Repositories - Взаимодействует с БД, содержит CRUD.
7)Services - Содержит бизнес-логику, взаимодействует с репозиториями.
# PostgreSQL
В качестве СУБД в проекте используется PostgreSQL, так как просто интегрируется с .NET через EF Core, работает с сложными структурами данных, готов к масштабированию (если функционал расширится).
Схема БД представлена в папке Image/db.png
# Сontrollers
ConsumptionController - Обработка HTTP-запросов, связанных с потреблением продуктов.
SupplementsController - Обработка HTTP-запросов, связанных с потреблением БАДов.
UserController - Обработка HTTP-запросов, связанных с пользователем.
# Data
BiogenomDbContext - Контекст EF Core.
# DataTransfer
UserDataTransfer, ProductConsumptionDataTransfer, SupplementDataTransfer - Классы преобразование данных, то есть в каком виде данные вернуться пользователю.
# Interface
IRepository - Базовый шаблон для работы с БД.
IUserRepository, ISupplementRepository, IProductConsumptionRepository - Наследуют IRepository и переопределяют методы для работы с определенными сущностями (users, productconsumption, supplements)
IUserService, ISupplementService, IProductConsumptionService - Представляют бизнес-логику приложения и связывают контроллеры и репозитории.
# Model
Users, UserActivity, UserSupplement, ProductConsumption, ProductCategory, ProductType, MeasurementUnit, ConsumptionFrequency, ActivityLevel, Supplement - Классы описывающие сущности БД.
# Repositories
BaseRepository, ProductConsumptionRepository, SupplementRepository, UserRepository - Реализация интересов I*Repository.
# Services
ProductConsumptionService, SupplementService, UserService -  Реализация интересов I*Services.
# Images
Данная папка содержит изображения схемы БД и диаграмму последовательности.
# Описание работы
Client отправляет HTTP-запрос в Controller, который вызывает нужный метод в Services. Services обращаются к Repository за данными, Repository выполняет SQL-запросы к БД. 
Полученные данные передаются обратно по цепочке: Repository возвращает результат в Services, Services преобразуют данные и передают в Controller, который формирует JSON-ответ и отправляет его клиенту. 
Вся работа строится по цепочке "Client -> Controller -> Services -> Repository -> БД -> Repository -> Services -> Controller -> Client", где каждый слой выполняет свою строго определённую задачу.
