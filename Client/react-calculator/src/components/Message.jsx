import { useState/*, useEffect*/ } from 'react'

const Message = ({ msgBody, variant, isDisplayed}) => {

  const [show, setShow] = useState(true)

  if (isDisplayed){
    setShow(true)
     setTimeout(() => {
      // After 3 seconds set the show value to false
      setShow(false)
    }, 3000)
  }

  // If show is false the component will return null and stop here
  if (!show) {
    return "null";
  }

  return (
    <div className={`text-center alert alert-${variant}`} >
      {msgBody}
    </div>
  )

}

Message.defaultPros = {
  variant: 'info',
  isDisplayed : true,
}

export default Message

