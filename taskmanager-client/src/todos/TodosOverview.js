import React, { Component } from 'react';
import { Container } from 'react-bootstrap';
import { DataOverview } from '../api/DataOverview';

export class TodosOverview extends Component {
  displayName = TodosOverview.name

  constructor(props) {
    super(props);
    this.state = { 
      error: null,
      isLoaded: false,
      projectId: props.match.params.projectId,
      todos: []
    };
  }

  componentDidMount()
  {
    fetch("https://localhost:5001/api/projects/" + this.state.projectId + "/todos")
      .then(res => res.json())
      .then((result) => {
        this.setState({
          ...this.state,
          isLoaded: true,
          todos: result
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

  //creates a new todo
  onCreate = () =>
  {
    //TODO: requires optimization (merge into one request)
    fetch("https://localhost:5001/api/todos/create?projectId="+this.state.projectId)
      .then(res => {console.log(res); return res.json()})
      .then(todo => this.onEdit(todo.id));
  }

  //edit a todo
  onEdit = (id) =>
  {
    this.props.history.push("/projects/" + this.state.projectId + "/todos/" + id + "/edit");
  }

  //delete a todo
  onDelete = (id) =>
  {
    fetch("https://localhost:5001/api/todos/" + id + "/delete")
      .then((result) => {
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
