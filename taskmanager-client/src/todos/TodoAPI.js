//handles todo data using /api/todos as its endpoint

var apiUrl = "https://localhost:5001/api";

export function getTodosOfProject (projectId, callback, callbackError)
{
    fetch(apiUrl + "/projects/" + projectId + "/todos")
    .then(res => res.json())
    .then((todos) => {
        if(callback)
            callback(todos);
    },
    (error) => {
        if(callbackError)
            callbackError(error);
    });
}

export function getTodo(todoId, callback, callbackError)
{
    fetch(apiUrl + "/todos/" + todoId)
    .then(res => res.json())
    .then((todo) => {
        if(callback)
            callback(todo);
    },
    (error) => {
        if(callbackError)
            callbackError(error);
    });
}

export function createTodo(projectId, callback, callbackError)
{
    fetch(apiUrl + "/todos/create?projectId="+projectId)
    .then(res => res.json())
    .then((project) => {
        if(callback)
            callback(project);
    },
    (error) => {
        if(callbackError)
            callbackError(error);
    });
}

export function updateTodo(todo, callback, callbackError)
{
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(todo)
      };

    fetch(apiUrl + "/todos/" + todo.id + "/update", requestOptions)
    //does not return json
    .then((result) => {
        if(callback)
            callback(result);
    },
    (error) => {
        if(callbackError)
            callbackError(error);
    });
}

export function deleteTodo(todoId, callback, callbackError)
{
    fetch(apiUrl + "/todos/" + todoId + "/delete")
    //does not return json
    .then((result) => {
        if(callback)
            callback(result);
    },
    (error) => {
        if(callbackError)
            callbackError(error);
    });
}