import React, { Component } from 'react';
import { Container } from 'react-bootstrap';
import { DataOverview } from '../api/DataOverview';
import { getTodosOfProject, createTodo, deleteTodo } from './TodoAPI';

export class TodosOverview extends Component {
  displayName = TodosOverview.name

  constructor(props) {
    super(props);
    this.state = { 
      projectId: props.match.params.projectId,
      error: null,
      isLoaded: false,
      todos: []
    };
  }

  componentDidMount()
  {
    getTodosOfProject(this.state.projectId, 
      (result) => {
        this.setState({
          ...this.state,
          isLoaded: true,
          todos: this.sortTodos(result)
        });
      },
      (error) => {
        this.setState({
          ...this.state,
          isLoaded: true,
          error
        });
      });
  }

  sortTodos = (todos) =>
  {
    return todos.sort(
      (a,b) => {
        return a.title.localeCompare(b.title);
      }
    );
  }

  //creates a new todo
  onCreate = () =>
  {
    createTodo(this.state.projectId,
      (todo) => {
        this.onEdit(todo.id, true);
      },
      (error) => console.log(error));
  }

  //edit a todo
  onEdit = (id, isNew) =>
  {
    var uri = "/projects/" + this.state.projectId + "/todos/" + id + "/edit";
    
    if(isNew)
    {
      uri += "?isNew="+isNew;
    }

    this.props.history.push(uri);
  }

  //delete a todo
  onDelete = (id) =>
  {
    deleteTodo(id, 
      (result) => {
        this.setState({
          ...this.state, 
          todos: this.state.todos.filter(x => x.id !== id)
        });
      },
      (error) => console.log(error));
  }

  renderTodo(todo)
  {
    return (
      <div>
        <label className="h3">{todo.title}</label>
        <pre className="text-secondary cut-text">{todo.description}</pre>
      </div>
    );
  }

  render() {
    const { error, isLoaded, todos } = this.state;
    if(error) {
      return <div>Error: {error.message}</div>
    }
    else if(!isLoaded) {
      return <div>Loading...</div>
    }
    else {
      return (
        <Container>
          <h1>Todos</h1>
          <DataOverview datas={todos} onCreate={this.onCreate} 
              onEdit={this.onEdit} onDelete={this.onDelete} render={this.renderTodo}/>
        </Container>
      );
    }
  }
}
