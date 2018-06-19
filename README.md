# Workshops.HW

## Данное ReadMe содержит список неточностей, которые необходимо исправить в проекте rocket.

1. [MailNotificationService](https://github.com/Suorness/Workshops.HW/blob/master/Day1.SOLID.HW/Rocket.BL/Services/Notification/MailNotificationService.cs) 
* удалить множество одинаковых catch (удалены) 
* использовать ``` nameof(DbUser) ``` вместо ```"DbUser"``` (метод SendBillingUserAsync)
* исправить путаницу с использованием ресурсов и перечисления ```BillingType``` (В методе SendBillingUserAsync используются значения переменных из ресурсов вместо перечисления)
* заменить упростить работу данного сервиса путем построения  ```templateBuilderMail service```, который формировал бы готовые письма для отправки.
2. [ChangeEmailManagerService](https://github.com/Suorness/Workshops.HW/blob/master/Day1.SOLID.HW/Rocket.BL/Services/PersonalArea/ChangeEmailManagerService.cs) 
* заменить валидацию данных (проверка соответствия стандарту email'а) на валидацию через атрибуты у модели [Email](https://github.com/Suorness/Workshops.HW/blob/master/Day1.SOLID.HW/Rocket.BL.Common/Models/PersonalArea/Email.cs) ```[EmailAddress]``` (и изменить имя поля "Name" на "Email")
* конструкции типа   
``` var model = _unitOfWork.EmailRepository.GetById(id);
    if (model == null)
    {
        throw new ValidationException(Resources.UndefinedEmail);
    }
```
можно упростить до           

```var model = _unitOfWork.EmailRepository.GetById(id) ?? throw new ValidationException(Resources.UndefinedEmail);```
3. [ChangeGenreManagerService](https://github.com/Suorness/Workshops.HW/blob/master/Day1.SOLID.HW/Rocket.BL/Services/PersonalArea/ChangeGenreManagerService.cs) 
* методы AddMusicGenre, AddTvGenre, DeleteMusicGenre, DeleteTvGenre  используется 2 обращения к базе данных, можно упростить до одного.
4. [FilmDetailedInfoService](https://github.com/Suorness/Workshops.HW/blob/master/Day1.SOLID.HW/Rocket.BL/Services/ReleaseList/FilmDetailedInfoService.cs)
* множество методов не реализовано или реализация закомментирована  (убрать лишние методы\убрать комментарии)
5. [SubscriptionService](https://github.com/Suorness/Workshops.HW/blob/master/Day1.SOLID.HW/Rocket.BL/Services/ReleaseList/SubscriptionService.cs)
* отсутствует документация к классу.
6. [UserManagementService](https://github.com/Suorness/Workshops.HW/blob/master/Day1.SOLID.HW/Rocket.BL/Services/User/UserManagementService.cs)
* в методе AddUser происходит генерация случайного id (генерацию лучше вынести в отдельных сервис) ```dbUser.Id = Guid.NewGuid().ToString();``` после этого без проверки наличия такого id происходит добавления пользователя.
* исправить (метод AddUser)
```
return result;
throw new InvalidOperationException(result.Errors.Aggregate((a, b) => $"{a} {b}"));
```
7. [UserValidateService](https://github.com/Suorness/Workshops.HW/blob/master/Day1.SOLID.HW/Rocket.BL/Services/User/UserValidateService.cs)
* метод UserValidateOnUpdating нереализован и отсутствуют пометки о TODO
8. [PermissionService](https://github.com/Suorness/Workshops.HW/blob/master/Day1.SOLID.HW/Rocket.BL/Services/UserServices/PermissionService.cs)
* закомментирована  большая часть имплементаций (убрать или реализовать)
9. [UnitOfWork](https://github.com/Suorness/Workshops.HW/blob/master/Day1.SOLID.HW/Rocket.DAL/UoW/UnitOfWork.cs)
* содержит большое число репозиториев, которые являются пустыми. Из-за отсутствия описанных методов в интерфейсе репозиториев в огромных  количествах дублируется код вида 
```
  var user = _unitOfWork.UserAuthorisedRepository.Get(x => x.DbUser_Id == id, null, "DbUser").First();
```
Для интерфейса репозиториев необходимо определить стандартные функции, такие как поиск пользователя по id и другие.

10. [AlbumInfoHelper](https://github.com/Suorness/Workshops.HW/blob/master/Day1.SOLID.HW/Rocket.Parser/Heplers/AlbumInfoHelper.cs)
* ```public const string CoversPath = @"c:\tmp\MusicCovers\";``` используется абсолютный путь к директориям. 
11. [LostfilmParser](https://github.com/Suorness/Workshops.HW/blob/master/Day1.SOLID.HW/Rocket.Parser/Parsers/LostfilmParser.cs)
* метод SaveResultInDb логирование ошибок производится через 
```Console.WriteLine(e);```
12. 
* В проекте присутствует множество связей  нарушающих 3-х уровневую архитектуру       

пример: Rocket.BL есть ссылка на Rocket.DAL 
* множество моделей, которые дублируют друг друга
* множество пустых интерфейсов, которые унаследованы от одного 
* множество классов, которые нарушают принцип единственной ответственности

