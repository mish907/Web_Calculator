import React from 'react'
import Card from 'react-bootstrap/Card';


const Cards = ({ key_id, header, title, text, functions, footer, style}) => {

  const cardStyle = style != null ? style : 'modal-dialog'

  return (
      <div key={key_id } className={cardStyle}>
        <Card className="text-center modal-content">
          <Card.Header >{header}</Card.Header>
          <Card.Body>
            <Card.Title>{title}</Card.Title>
            <div className="card-text mb-2">
              {text}
            </div>
            {functions}
          </Card.Body>
          <Card.Footer className="text-muted">{footer}</Card.Footer>
        </Card>
      </div>
  ) 
}

export default Cards