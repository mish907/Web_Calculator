import React from "react";

const Field = ({ id, input, type, value, style, onchange, ac, minL, maxL, size, isDisabled}) => (
  <div className="form-floating m-1" >
       <input type={type} className={style} id={id} name={id} value={value} 
              onChange={onchange} placeholder={input} autoComplete={ac}
              minLength={minL} maxLength={maxL} size={size} disabled = {isDisabled} required
       />
    <label htmlFor={id} className="form-label"></label>
  </div>
);

Field.defaultProps = {
  input: "text",
  style: "form-control",
  minL: 1,
  maxL: 25,
  isDisabled : false
};

export default Field;
