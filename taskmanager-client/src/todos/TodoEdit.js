import React, { Component } from 'react';
import { Form } from 'react-bootstrap';
import { DataEdit } from '../api/DataEdit';
import { getTodo, deleteTodo, updateTodo } from './TodoAPI';

export class TodoEdit extends Component {
  displayName = TodoEdit.name

  constructor(props) {
    super(props);

    this.state = { 
      projectId: props.match.params.projectId,
      todoId: props.match.params.todoId,
      isNew: new URLSearchParams(this.props.location.search).get("isNew"),
      error: null,
      isLoaded: false,
      todo: null
    };
  }

  componentDidMount()
  {
    getTodo(this.state.todoId, 
      (result) => {
        this.setState({
          isLoaded: true,
          todo: result
        });
      },
      (error) => {
        this.setState({
          isLoaded: true,
          error
        });
      });
  }

  onTitleChanged = (e) =>
  {
    this.setTodo({...this.state.todo, title: e.target.value});
  }

  onDescriptionChanged = (e) =>
  {
    this.setTodo({...this.state.todo, description: e.target.value});
  }

  setTodo(todo)
  {
    this.setState({
      ...this.state,
      todo: todo
    });
  }

  onSave = () =>
  {
    updateTodo(this.state.todo, 
      (result) => {
        this.goToTodos();
      },
      (error) => console.log(error));
  }

  onAbort = () =>
  {
    if(this.state.isNew)
    {
      deleteTodo(this.state.todoId,
        (result) => this.goToTodos(),
        (error) => console.log(error));
    }
    else{
      this.goToTodos();
    }
  }

  goToTodos(){
    this.props.history.push("/projects/"+this.state.projectId+"/todos");
  }

  renderTodo = (todo) =>
  {
    return(
    <Form>
      <Form.Group>
        <Form.Label>Title</Form.Label>
        <Form.Control type="text" defaultValue={todo.title} onChange={this.onTitleChanged} />
      </Form.Group>
      <Form.Group>
        <Form.Label>Description</Form.Label>
        <Form.Control as="textarea" rows="3" defaultValue={todo.description} onChange={this.onDescriptionChanged} />
      </Form.Group>
    </Form>
    );
  }

  render() {
    const { error, isLoaded, todo } = this.state;
    if(error) {
      return <div>Error: {error.message}</div>
    }
    else if(!isLoaded) {
      return <div>Loading...</div>
    }
    else {
      return (
        <DataEdit title={todo.title || "Todo"} render={() => this.renderTodo(todo)}
          onSave={this.onSave} onAbort={this.onAbort} />
      );
    }
  }
}
