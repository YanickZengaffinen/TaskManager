import React, { Component } from 'react';
import { Navbar, Nav, NavDropdown, Form, FormControl, Button } from 'react-bootstrap';

export class Navigation extends Component {
  displayName = Navigation.name

  render() {
    return (
      <div>
    <Navbar bg="dark">
      <Nav>
        <Nav.Item>
          <Nav.Link href="/" className="text-light">Home</Nav.Link>
        </Nav.Item>
        <Nav.Item>
          <Nav.Link href="/projects" className="text-light">Projects</Nav.Link>
        </Nav.Item>
      </Nav>
    </Navbar>
      </div>
    );
  }
}
