import React, { Component } from 'react';
import { Container } from 'react-bootstrap';
import { faTimes, faSave } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

export class DataEdit extends Component {
  displayName = DataEdit.name

  constructor(props) {
    super(props);
    
    this.state = {};
  }

  static getDerivedStateFromProps(props, state)
  {
    return { 
      title: props.title,
      onSave: props.onSave,
      onAbort: props.onAbort,
      render: props.render,
    };
  }

  render() {
    const { title, onSave, onAbort, render } = this.state;
    return (
    <Container>
        <h1 className="d-inline">{title}</h1>
        
        {render()}

        <footer className="footer mb-1">
        <Container fluid>
            <div className="border border-dark">
            <FontAwesomeIcon className="icon d-inline float-right" 
                icon={faTimes} onClick={onAbort}/>
            <FontAwesomeIcon icon={faSave} className="icon float-right mx-1" onClick={onSave} />
            </div>
        </Container>
        </footer>
    </Container>
    );
  }
}
