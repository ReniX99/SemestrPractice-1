## Инструкция

### Установка
Для запуска программы убедитесь, что у вас установлен PostgreSQL и .NET.SDK на устройстве 

### Запуск
Для запуска проекта введите следующие команды:
1. Клонировать указанный репозиторий
```{git}
git clone https://github.com/ReniX99/SemestrPractice-1
```

2. Изменить файл **`appsettings.json`** в папке back
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=ToDoListdb;Username=your-username;Password=your-password"
  }
}
```
В качестве значений ключей Username и Password введите свои данные от учётной записи PostgreSQL

3. Запустить сервер (5194 порт):
```{bash}
cd back
dotnet ef database update
dotnet run
```

4. Запустить фронтенд (5173 порт):
```{bash}
cd front
npm install
npm run dev
```
