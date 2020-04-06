import React, { Component } from 'react';
import { Form } from 'react-bootstrap';
import { getProject, updateProject, deleteProject } from './ProjectAPI';
import { DataEdit } from '../api/DataEdit';

export class ProjectEdit extends Component {
  displayName = ProjectEdit.name

  constructor(props) {
    super(props);
    this.state = { 
      projectId: props.match.params.projectId,
      isNew: new URLSearchParams(this.props.location.search).get("isNew"),
      error: null,
      isLoaded: false,
      project: null
    };
  }

  componentDidMount()
  {
    getProject(this.state.projectId, 
      (result) => {
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
      }
    );
  }

  onProjectNameChanged = (e) =>
  {
    this.setProject({...this.state.project, name: e.target.value });
  }

  onProjectDescriptionChanged = (e) =>
  {
    this.setProject({...this.state.project, description: e.target.value });
  }

  setProject(project)
  {
    this.setState({
      ...this.state,
      project: project
    });
  }

  onSave = () =>
  {
    updateProject(this.state.project, 
      (result) => this.goToProjects(),
      (error) => console.log(error));
  }

  onAbort = () =>
  {
    console.log(this.state.isNew);
    if(this.state.isNew)
    {
      deleteProject(this.state.projectId,
        (result) => this.goToProjects(),
        (error) => console.log(error)
      );
    }
    else{
      this.goToProjects();
    }
  }

  //return to /projects
  goToProjects()
  {
    this.props.history.push("/projects");
  }

  renderProject(project)
  {
    return (
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
    );
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
        <DataEdit title={project.name || "Project"} render={() => this.renderProject(project)}
          onSave={this.onSave} onAbort={this.onAbort} />
      );
    }
  }
}
