import React, { useEffect, useRef } from 'react'
import { useNavigate, useSearchParams } from 'react-router-dom'
import { INPUT_ELEMENTS, INPUT_TYPES } from '../constants/inputs'
import Form from '../utility/Form'
import Button from '../utility/Button'

function Register() {
  const navigate = useNavigate()
  const [searchParams] = useSearchParams()

  const emailRef = useRef()

  useEffect(() => {
    if (searchParams.get('email')) {
      emailRef.current.value = searchParams.get('email')
    }
  }, [searchParams])

  const inputFields = [
    {
      name: 'email',
      placeholder: 'email@example.com',
      type: INPUT_TYPES.EMAIL,
      required: true,
      inputElement: INPUT_ELEMENTS.INPUT,
      className: 'plain',
      ref: emailRef
    },
    {
      name: 'password',
      placeholder: 'Enter password',
      type: INPUT_TYPES.PASSWORD,
      required: true,
      inputElement: INPUT_ELEMENTS.INPUT,
      className: 'plain',
      ref: useRef()
    },
    {
      name: 'confirm-password',
      placeholder: 'Confirm password',
      type: INPUT_TYPES.PASSWORD,
      required: true,
      inputElement: INPUT_ELEMENTS.INPUT,
      className: 'plain',
      ref: useRef()
    }
  ]

  const buttons = [
    {
      type: 'submit',
      component: <Button type='submit' text='Continue' className='primary capsule full-width mt-3' action={() => { }} />
    }
  ]

  return (
    <div className='content form'>
      <div className='form-wrapper'>
        <h2>Sign up</h2>
        <h4>Already have an account? <button className='link' onClick={() => { navigate('/login') }}>Log In</button></h4>
        <Form inputs={inputFields} buttons={buttons} />
      </div>
    </div>
  )
}

export default Register