import React, { useEffect, useState } from 'react'
import { useNavigate, useSearchParams } from 'react-router-dom'
import { INPUT_ELEMENTS, INPUT_TYPES } from '../constants/inputs'
import Form from '../utility/Form'
import Button from '../utility/Button'

function Register() {
  const navigate = useNavigate()
  const [searchParams] = useSearchParams()
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [confirmPassword, setConfirmPassword] = useState('')

  useEffect(() => {
    if (searchParams.get('email')) {
      setEmail(searchParams.get('email'))
    }
  }, [searchParams])

  const inputFields = [
    {
      name: 'email',
      placeholder: 'email@example.com',
      type: INPUT_TYPES.EMAIL,
      required: true,
      inputElement: INPUT_ELEMENTS.INPUT,
      state: email,
      setState: setEmail,
      className: 'plain'
    },
    {
      name: 'password',
      placeholder: 'Enter password',
      type: INPUT_TYPES.PASSWORD,
      required: true,
      inputElement: INPUT_ELEMENTS.INPUT,
      state: password,
      setState: setPassword,
      className: 'plain'
    },
    {
      name: 'confirm-password',
      placeholder: 'Confirm password',
      type: INPUT_TYPES.PASSWORD,
      required: true,
      inputElement: INPUT_ELEMENTS.INPUT,
      state: confirmPassword,
      setState: setConfirmPassword,
      className: 'plain'
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