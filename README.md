# Introduction
CRUD (Create, Read, Update, Delete) Minimal Api that allows you to manage your applications.

## Application Entity

```
public class Application
{
    public int Id { get; set; }
    public required string CompanyName { get; set; }

    public int TitleId { get; set; }
    public Title? Title { get; set; }
    public DateOnly Deadline { get; set; }
}
```

## HTTP Requests and Responses

| API | Description | Request Body | Response Body|
|-----|-------------|--------------|--------------|
|Get /api/applications | Get all application items | None | Array of application items|
|GET /api/applications/{id} |Get an item by ID |	None |	application item|
|POST /api/applications	| Add a new item |	application item |	application item|
|PUT /api/applications/{id}	| Update an existing item | 	application item|	None|
|DELETE /api/applications/{id}  |	Delete an item   | 	None|	None|
