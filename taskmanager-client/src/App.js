import React, { Component } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import { ProjectsOverview } from './projects/ProjectsOverview';
import { ProjectEdit } from './projects/ProjectEdit';
import { TodosOverview } from './todos/TodosOverview';
import { TodoEdit } from './todos/TodoEdit';
import { Navigation } from './Navigation';

export class App extends Component {
  displayName = App.name

  render() {
    return (
    <div>
        <BrowserRouter>
            <div>
            <Navigation />
            <Switch>
                <Route exact path="/" component={ProjectsOverview}/>
                <Route exact path="/projects" component={ProjectsOverview} />
                <Route exact path="/projects/:projectId/edit" component={ProjectEdit} />
                <Route exact path="/projects/:projectId/todos" component={TodosOverview} />
                <Route exact path="/projects/:projectId/todos/:todoId/edit" component={TodoEdit} />
            </Switch>
            </div>
        </BrowserRouter>

    </div>
    );
  }
}
