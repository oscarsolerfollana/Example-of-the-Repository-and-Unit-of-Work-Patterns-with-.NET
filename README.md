# Example of the Repository and Unit of Work Patterns with .NET

> In this example, I want to show an implementation of Repository Pattern and Unit of Work Pattern in .NET. We will use Entity Framework to connect to a Data Base.
<br/>



### Generic Repository

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

This class contains all the methods for creating, deleting and manipulating data with Entity Framework.
Once the generic repository class is created, we create

(Under construction...)
