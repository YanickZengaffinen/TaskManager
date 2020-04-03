import React, { Component } from 'react';
import { Container, Form } from 'react-bootstrap';

export class TodoEdit extends Component {
  displayName = TodoEdit.name

  constructor(props) {
    super(props);

    this.state = { 
      projectId: props.match.params.projectId,
      todoId: props.match.params.todoId,
      error: null,
      isLoaded: false,
      todo: null
    };
  }

  componentDidMount()
  {
    fetch("https://localhost:5001/api/todos/" + this.state.todoId)
      .then(res => res.json())
      .then((result) => {
        console.log(result);
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
    this.setState({
      ...this.state,
      todo:
      {
        ...this.state.todo,
        title: e.target.value
      }
    });
  }

  onDescriptionChanged = (e) =>
  {
    this.setState({
      ...this.state,
      todo:
      {
        ...this.state.todo,
        description: e.target.value
      }
    });
  }

  save = () =>
  {
    const requestOptions = {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(this.state.todo)
    };
    fetch("https://localhost:5001/api/todos/" + this.state.todoId + "/update", requestOptions)
        .then(e => this.props.history.push("/projects/"+this.state.projectId+"/todos"));
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
        <Container>
          <h1>{todo.title || "Todo"}</h1>
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

          <footer className="footer mb-1">
            <Container fluid>
              <button className="btn btn-primary float-right mx-1" onClick={this.save}>Save</button>
            </Container>
          </footer>
        </Container>
      );
    }
  }
}
