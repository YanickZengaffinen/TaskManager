import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import * as serviceWorker from './serviceWorker';
import { BrowserRouter, Route } from 'react-router-dom';
import { ProjectsOverview } from './projects/ProjectsOverview';
import { ProjectEdit } from './projects/ProjectEdit';
import { TodosOverview } from './todos/TodosOverview';
import { TodoEdit } from './todos/TodoEdit';

const routing = (
  <BrowserRouter>
    <div>
      <Route exact path="/" component={ProjectsOverview}/>
      <Route exact path="/projects" component={ProjectsOverview} />
      <Route exact path="/projects/:projectId/edit" component={ProjectEdit} />
      <Route exact path ="/projects/:projectId/todos" component={TodosOverview} />
      <Route exact path ="/projects/:projectId/todos/:todoId/edit" component={TodoEdit} />
    </div>
  </BrowserRouter>
);

ReactDOM.render(
  routing,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
