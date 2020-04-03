import React, { Component } from 'react';
import { Container } from 'react-bootstrap'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPlus, faEdit, faTrash } from '@fortawesome/free-solid-svg-icons'

export class DataOverview extends Component {
  displayName = DataOverview.name

  constructor(props) {
    super(props);
    
    this.state = {};
  }

  static getDerivedStateFromProps(props, state)
  {
    return { 
      datas: props.datas,
      onDataClicked: props.onDataClicked,
      onCreate: props.onCreate,
      onEdit: props.onEdit,
      onDelete: props.onDelete,
      render: props.render,
    };
  }

  render() {
    if(this.state == null) return (<div></div>);
    const { datas, onDataClicked, onCreate, onEdit, onDelete, render } = this.state;
    return (
        <div>
          <ul className="list-group">
              {datas.map((data) => 
                <li key={data.id} className="list-group-item" onClick={() => {console.log("top"); if(onDataClicked) onDataClicked(data.id)}}>
                    <Container fluid>
                        {render(data)}
                        <FontAwesomeIcon className="icon float-right"
                            icon={faTrash} onClick={e => {console.log("miau"); e.stopPropagation(); e.preventDefault(); onDelete(data.id)}} />
                        <FontAwesomeIcon className="icon float-right"
                            icon={faEdit} onClick={e => {console.log(e); e.stopPropagation(); e.preventDefault(); onEdit(data.id)}} />
                    </Container>
                </li>
              )}
            <li key="placeholder" className="list-group-item" onClick={onCreate}>
              <div className="row justify-content-center">
                <FontAwesomeIcon className="icon" icon={faPlus} />
              </div>
            </li>
          </ul>  
        </div>
      );
  }
}
