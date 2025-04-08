import React, { useState, useEffect } from "react";
import Card from "./Card";

const HistoryList = () => {
  const [message, setMessage] = useState();
  const [history, setHistory] = useState([]);

  useEffect(() => {
    let data;
    fetch(`http://localhost:5091/api/calculator`)
      .then(async (response) => {
        data = await response.json();
        // check for error response
        if (!response.ok) {
          // get error message from body or default to response status
          const error = (data && data.message) || response.status;
          return Promise.reject(error);
        }
        setHistory(data);
      })
      .catch((error) => {
        showMessage("There is no stored calculation history yet...", "danger");
      });
  });

  function showMessage(msg, type) {
    setMessage(<Message msgBody={msg} variant={type} />);
  }

  const [toCalculate, setToCalculate] = useState({
    firstNumber: "",
    operator: "",
    secondNumber: "",
    result: "",
  });

  const operatorOptions = [
    { value: 1, label: "+" },
    { value: 2, label: "-" },
    { value: 3, label: "*" },
    { value: 4, label: "/" },
  ];

  const getLabelByValue = (value) => {
    const option = operatorOptions.find((option) => option.value === value);
    return option ? option.label : "Unknown";
  };

  return (
    <div className="container padding w-full bg-blue-200 p-4 mb-4 text-center">
      {message ? message : history.map((calc) => (
            <div key={calc.id}>
              <Card
                key_id={calc.id}
                title={`${calc.id}. ${calc.firstNumber}${getLabelByValue(
                  calc.operator
                )}${calc.secondNumber} = ${calc.result}`}
              />
            </div>
          ))}
    </div>
  );
};

export default HistoryList;
