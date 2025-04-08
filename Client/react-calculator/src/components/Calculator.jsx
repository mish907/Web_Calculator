import { useState } from "react";
import Button from "./Button";
import Field from "./Field";
import Select from "react-select";
import Message from "./Message";
import HistoryList from "./HistoryList";

import "bootstrap/dist/css/bootstrap.min.css";

function Calculator() {
  const [toCalculate, setToCalculate] = useState({
    firstNumber: "",
    operator: "",
    secondNumber: "",
    result: "",
  });

  const operatorOptions = [
    { value: 1, label: "Addition" },
    { value: 2, label: "Subtraction" },
    { value: 3, label: "Multiplication" },
    { value: 4, label: "Division" },
  ];

  function handleChange(event) {
    const { name, value } = event.target;

    setToCalculate((prevState) => {
      return {
        ...prevState,
        [name]: value,
      };
    });
  }

  const Calculate = (event) => {
    console.log(toCalculate.operator);
    if (isValid()) {
      sendRequest();
    } else {
      showMessage("Please fill the fields, only with digits. and or select the right Operator", "warning");
    }
  };

  function isValid() {
    return (
      toCalculate.firstNumber !== "" &&
      !isNaN(+toCalculate.firstNumber) &&
      toCalculate.secondNumber !== "" &&
      !isNaN(+toCalculate.secondNumber) &&
      toCalculate.operator !== ""
    );
  }

  const [message, setMessage] = useState();

  function showMessage(msg, type) {
    setTimeout(() => {
      setMessage(<Message isDisplayed={false} />);
    }, 5000);
    setMessage(<Message msgBody={msg} variant={type} />);
  }

  const sendRequest = () => {
    let data;
    const requestOptions = {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(toCalculate),
    };

    fetch("http://localhost:5091/api/calculator", requestOptions)
      .then(async (response) => {
        //data = await response.text();
        data = await response.json();

        if (!response.ok) {
          const error = (data && data.message) || response.status;
          return Promise.reject(error);
        }

        //setToCalculate(data)

        setToCalculate({
          ...toCalculate,
          result: data.result,
        });

        showMessage(`New calculation was saved`, "success");
      })
      .catch((error) => {
        data = JSON.parse(data);
        showMessage(data.message, "danger");
      });
  };

  function isEmpty() {
    var toReturn = false;
    // eslint-disable-next-line array-callback-return
    Object.values(toCalculate).map((value) => {
      if (value === "") {
        toReturn = true;
      }
    });
    return toReturn;
  }

  return (
    <>
      {message ? message : null}

      <div className="container padding w-full bg-blue-200 p-4 mb-4 text-center" style={{ display: "flex", flexDirection: "column", alignItems: "center",}}>
        
        <div className="App centered-div" style={{ display: "flex", flexDirection: "row", alignItems: "center", }}>
          
          <Field id="firstNumber" input="Field 1" value={toCalculate.firstNumber} onchange={handleChange} />

          <Select className="m-2" options={operatorOptions} defaultValue={{ label: "Select Operation" }} onChange={(s) => handleChange({ target: { name: "operator", value: s.value } }) } id="operator"/>

          <Field id="secondNumber" input="Field 2" value={toCalculate.secondNumber} onchange={handleChange} />

          <Button onClick={Calculate} color="success" text="Calculate" />
        </div>
        <div className="w-full p-2 mb-4">

          <Field id="result" input="Result:" value={toCalculate.result} onchange={handleChange} size={85} isDisabled = {true}/>

        </div>
      </div>
      <HistoryList/>
    </>
  );
}

export default Calculator;
