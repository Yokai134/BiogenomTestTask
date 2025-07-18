# Biogenom
Web API �������� �� ��������� ������ �����������:
1)Controllers - ���������� API, ��������� ������� � ���������� ���������.
2)Data - ������������ EF Core.
3)DataTransfer - ���������� �� ��� �������� ������������.
4)Interface - ������� ��� ��������, ������������.
5)Model - ��������� �������� ��.
6)Repositories - ��������������� � ��, �������� CRUD.
7)Services - �������� ������-������, ��������������� � �������������.
# PostgreSQL
� �������� ���� � ������� ������������ PostgreSQL, ��� ��� ������ ������������� � .NET ����� EF Core, �������� � �������� ����������� ������, ����� � ��������������� (���� ���������� ����������).
����� �� ������������ � ����� Image/db.png
# �ontrollers
ConsumptionController - ��������� HTTP-��������, ��������� � ������������ ���������.
SupplementsController - ��������� HTTP-��������, ��������� � ������������ �����.
UserController - ��������� HTTP-��������, ��������� � �������������.
# Data
BiogenomDbContext - �������� EF Core.
# DataTransfer
UserDataTransfer, ProductConsumptionDataTransfer, SupplementDataTransfer - ������ �������������� ������, �� ���� � ����� ���� ������ ��������� ������������.
# Interface
IRepository - ������� ������ ��� ������ � ��.
IUserRepository, ISupplementRepository, IProductConsumptionRepository - ��������� IRepository � �������������� ������ ��� ������ � ������������� ���������� (users, productconsumption, supplements)
IUserService, ISupplementService, IProductConsumptionService - ������������ ������-������ ���������� � ��������� ����������� � �����������.
# Model
Users, UserActivity, UserSupplement, ProductConsumption, ProductCategory, ProductType, MeasurementUnit, ConsumptionFrequency, ActivityLevel, Supplement - ������ ����������� �������� ��.
# Repositories
BaseRepository, ProductConsumptionRepository, SupplementRepository, UserRepository - ���������� ��������� I*Repository.
# Services
ProductConsumptionService, SupplementService, UserService -  ���������� ��������� I*Services.
# �������� ������
������������ ���������� ������ � API � �������� ������. ����� ������ ������������ � ����� Image/schema.png
