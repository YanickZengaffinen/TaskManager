//handles project data using /api/projects as its endpoint

var apiUrl = "https://localhost:5001/api";

export function getProjects (callback, callbackError)
{
    fetch(apiUrl + "/projects")
    .then(res => res.json())
    .then((projects) => {
        if(callback)
            callback(projects);
    },
    (error) => {
        if(callbackError)
            callbackError(error);
    });
}

export function getProject(projectId, callback, callbackError)
{
    fetch(apiUrl + "/projects/" + projectId)
    .then(res => res.json())
    .then((projects) => {
        if(callback)
            callback(projects);
    },
    (error) => {
        if(callbackError)
            callbackError(error);
    });
}

export function createProject(callback, callbackError)
{
    fetch(apiUrl + "/projects/create")
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

export function updateProject(project, callback, callbackError)
{
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(project)
      };

    fetch(apiUrl + "/projects/" + project.id + "/update", requestOptions)
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

export function deleteProject(projectId, callback, callbackError)
{
    fetch(apiUrl + "/projects/" + projectId + "/delete")
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