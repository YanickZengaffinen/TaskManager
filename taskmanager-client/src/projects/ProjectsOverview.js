import React, { Component } from 'react';
import { Container } from 'react-bootstrap';
import { DataOverview } from '../api/DataOverview';
import { getProjects, createProject, deleteProject } from './ProjectAPI';
import './ProjectsOverview.css';

export class ProjectsOverview extends Component {
  displayName = ProjectsOverview.name

  constructor(props) {
    super(props);
    this.state = { 
      error: null,
      isLoaded: false,
      projects: []
    };
  }

  componentDidMount()
  {
    getProjects(
      (projects) => this.setState({
        isLoaded: true,
        projects: this.sortByActive(projects)
      }),
      (error) => {
        this.setState({
          isLoaded: true,
          error
        })
      }
    );    
  }

  //sorts the projects by active, alphabet
  sortByActive = (projects) =>
  {
    return projects.sort((a,b) => {
      if(a.active)
      {
        if(b.active)
        {
          //compare alphabetically
          return a.name.localeCompare(b.name);
        }
        else
        {
          return -1;
        }
      }
      //a inactive
      else if(b.active)
      {
        return 1;
      }
      else
      {
        return a.name.localeCompare(b.name);
      }
    });
  }

  //creates a new project
  onCreate = () =>
  {
    createProject(
      (project) => {
        this.onEdit(project.id, true);
      },
      (error) => console.log(error));
  }

  //edit a project
  onEdit = (id, isNew) =>
  {
    var uri = "/projects/" + id + "/edit";
    
    if(isNew)
    {
      uri += "?isNew="+isNew;
    }

    this.props.history.push(uri);
  }

  //delete a project
  onDelete = (id) =>
  {
    deleteProject(id, 
      (result) => {
        this.setState({
          ...this.state, 
          projects: this.sortByActive(this.state.projects.filter(x => x.id !== id))
        });
      },
      (error) => console.log(error));
  }

  showTodos = (projectId) =>
  {
    this.props.history.push("/projects/" + projectId + "/todos");
  }

  renderProject(project)
  {
    if(project.active)
    {
      return(
        <div className={"d-inline active"}>
          <label className="h3">{project.name}</label>
          <pre className="text-secondary cut-text">{project.description}</pre>
        </div>
      );
    }
    else
    {
      return(
        <div className={"d-inline inactive"}>
          <label className="h3">{project.name + " (inactive)"}</label>
          <pre className="text-secondary cut-text">{project.description}</pre>
        </div>
      );
    }
  }

  render() {
    const { error, isLoaded, projects } = this.state;
    if(error) {
      return <div>Error: {error.message}</div>
    }
    else if(!isLoaded) {
      return <div>Loading...</div>
    }
    else {
      return (
        <div>
          <Container>
            <h1>Projects</h1>
            <DataOverview datas={projects} onDataClicked={this.showTodos}
              onCreate={this.onCreate} onEdit={this.onEdit} onDelete={this.onDelete} 
              render={this.renderProject}/>
          </Container>
        </div>

      );
    }
  }
}
