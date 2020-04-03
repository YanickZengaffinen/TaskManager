import React, { Component } from 'react';
import { Container, Form } from 'react-bootstrap';

export class ProjectEdit extends Component {
  displayName = ProjectEdit.name

  constructor(props) {
    super(props);
    this.state = { 
      projectId: props.match.params.projectId,
      error: null,
      isLoaded: false,
      project: null
    };
  }

  componentDidMount()
  {
    fetch("https://localhost:5001/api/projects/" + this.state.projectId)
      .then(res => res.json())
      .then((result) => {
        this.setState({
          isLoaded: true,
          project: result
        });
      },
      (error) => {
        this.setState({
          isLoaded: true,
          error
        });
      });
  }

  onProjectNameChanged = (e) =>
  {
    this.setState({
      ...this.state,
      project:
      {
        ...this.state.project,
        name: e.target.value
      }
    });
  }

  onProjectDescriptionChanged = (e) =>
  {
    this.setState({
      ...this.state,
      project:
      {
        ...this.state.project,
        description: e.target.value
      }
    });
  }

  save = () =>
  {
    const requestOptions = {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(this.state.project)
    };
    fetch("https://localhost:5001/api/projects/" + this.state.projectId + "/update", requestOptions)
        .then(e => this.props.history.push("/projects"));
  }

  render() {
    const { error, isLoaded, project } = this.state;
    if(error) {
      return <div>Error: {error.message}</div>
    }
    else if(!isLoaded) {
      return <div>Loading...</div>
    }
    else {
      return (
        <Container>
          <h1>{project.name || "Project"}</h1>
          <Form>
            <Form.Group>
              <Form.Label>Name</Form.Label>
              <Form.Control type="text" defaultValue={project.name} onChange={this.onProjectNameChanged} />
            </Form.Group>
            <Form.Group>
              <Form.Label>Description</Form.Label>
              <Form.Control as="textarea" rows="3" defaultValue={project.description} onChange={this.onProjectDescriptionChanged} />
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
