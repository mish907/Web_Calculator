import React from 'react';

const Button = ({b_style, color, text , onClick ,isDisabled}) => (
  <button className={b_style+color}  onClick={onClick} disabled={isDisabled}>
    {text}
  </button>
);

Button.defaultProps = {
  text: '',
  color: '',
  b_style: 'w-100 btn btn-lg btn-',
  isDisabled: false
};



export default Button;