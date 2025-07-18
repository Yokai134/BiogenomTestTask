# Biogenom
Web API построен по принципам чистой архитектуры:
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
# Описание работы
Пользователь отправляет запрос в API и получает данные. Схема данных представлена в папке Image/schema.png
