# Example of the Repository and Unit of Work Patterns with .NET

> In this example, I want to show an implementation of Repository Pattern and Unit of Work Pattern in .NET. We will use Entity Framework to connect to a database.
<br/>


#### Table of Contents
[DbContext](#dbContext)<br/>
[Generic Repository](#generic-repository)<br/>
[Unit of Work](#unit-of-work)<br/>

## DbContext

Firstly, we create our Database Context.
In the overriden OnModelCreating method, we will need to map our entities fields with the tables columns of the database, in addition to other configurations (like primary key).

```c#
protected override void OnModelCreating(ModelBuilder builder)
{
    //Users
    builder.Entity<User>().HasKey(table => new {
        table.Id
    });
    builder.Entity<User>().Property(p => p.Name).HasColumnName("Nombre");
    builder.Entity<User>().Property(p => p.Surnames).HasColumnName("Apellidos");
    builder.Entity<User>().ToTable("Usuarios");
...
```

## Generic Repository

We create a Generic Repository in our Data Access Layer (DAL), through which we can access to our database.

```c#
...
public virtual void Insert(TEntity entity)
{
    dbSet.Add(entity);
    context.SaveChanges();
}

public virtual void Delete(object id)
{
    TEntity entityToDelete = dbSet.Find(id);
    Delete(entityToDelete);
    context.SaveChanges();
}
...
```
 
Repositories encapsulates the methods for creating, deleting and manipulating the data of a single entity with Entity Framework.
Once the generic repository class is created, we need to create a Unit of Work class.

## Unit of Work

A Unit of Work is a tool which can be used to make one transaction that involves one or more database operations.

```c#
...
public GenericRepository<User> UsersRepository
{
    get
    {
        if (usersRepository == null)
        {
            usersRepository = new GenericRepository<User>(dowJonesContext);
        }
        return usersRepository;
    }
}

public GenericRepository<Stock> StocksRepository
{
    get
    {
        if (stocksRepository == null)
        {
            stocksRepository = new GenericRepository<Stock>(dowJonesContext);
        }
        return stocksRepository;
    }
}

public void Save()
{
    dowJonesContext.SaveChanges();
}
...
```

The Unit of Work class shares the same DbContext with all its repositories. This way, you can make one single transaction, even if it involves more than one repositories. Doing SaveChanges() at the end, when Save method of UnitOfWork is called, will make succeed or fail every changes at the same time.
