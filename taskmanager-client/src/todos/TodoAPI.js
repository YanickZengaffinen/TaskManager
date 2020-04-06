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
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({projectId: projectId})
    };

    fetch(apiUrl + "/todos", requestOptions)
    .then(res => res.json())
    .then((result) => {
        if(callback)
            callback(result);
    },
    (error) => {
        if(callbackError)
            callbackError(error);
    });
}

export function updateTodo(todo, callback, callbackError)
{
    const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(todo)
    };

    fetch(apiUrl + "/todos/" + todo.id, requestOptions)
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
    const requestOptions = {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' }
    };

    fetch(apiUrl + "/todos/" + todoId, requestOptions)
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