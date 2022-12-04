import React, { useRef } from 'react'
import { useNavigate } from 'react-router-dom'
import { INPUT_ELEMENTS, INPUT_TYPES } from '../constants/inputs'
import Form from '../utility/Form'
import Button from '../utility/Button'

function Login() {
    const navigate = useNavigate()

    const inputFields = [
        {
            name: 'email',
            placeholder: 'email@example.com',
            type: INPUT_TYPES.EMAIL,
            required: true,
            inputElement: INPUT_ELEMENTS.INPUT,
            className: 'plain',
            ref: useRef(),
            errorRef: useRef()
        },
        {
            name: 'password',
            placeholder: 'Your password',
            type: INPUT_TYPES.PASSWORD,
            required: true,
            inputElement: INPUT_ELEMENTS.INPUT,
            className: 'plain',
            ref: useRef(),
            errorRef: useRef()
        }
    ]

    const buttons = [
        {
            type: 'submit',

            component: <Button type='submit' text='Continue' className='primary capsule full-width mt-3' />
        },
        {
            type: 'button',
            component: <Button text='Forgot password?' className='' action={() => {}} />
        }
    ]

    return (
        <div className='content form'>
            <div className='form-wrapper'>
                <h2>Log in</h2>
                <h4>First time? <button className='link' onClick={() => { navigate('/signup') }}>Sign Up</button></h4>
                <Form inputs={inputFields} buttons={buttons} />
            </div>
        </div>
    )
}

export default Login