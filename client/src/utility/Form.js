import React, { useEffect, useState } from 'react'
import { INPUT_ELEMENTS } from '../constants/inputs'
import useForm from '../hooks/useForm'

function Input(props) {
    const { input, error } = props
    const [focus, setFocus] = useState(false)
    const [inputError, setInputError] = useState({ field: '', message: '' })

    useEffect(() => {
        if (focus) input.ref.current.focus()
    }, [focus, input.ref])

    useEffect(() => {
        let errorElement = error.find(errorElement => errorElement.field === input.name)
        if (errorElement) {
            setInputError({ field: errorElement.field, message: errorElement.message })
        } else {
            setInputError({ field: '', message: '' })
        }
    }, [error, input.name])

    return (
        <>
            <div onClick={() => setFocus(true)} className={'input-wrapper full-width ' + input.className + (focus ? ' focus ' : '') + (inputError.field === input.name ? ' error ' : '')}>
                <input
                    name={input.name}
                    ref={input.ref}
                    onFocus={() => setFocus(true)}
                    onBlur={() => setFocus(false)}
                    type={input.type}
                    placeholder={input.placeholder} />
            </div>
            <p className={'form-error-message text-danger' + (true ? '' : 'display-none')}>{inputError.message}</p>
        </>
    )
}

function SwitchRender(props) {
    const { input, error } = props

    switch (input.inputElement) {
        case INPUT_ELEMENTS.INPUT:
            return (
                <Input error={error} input={input} />
            )

        case INPUT_ELEMENTS.TEXTAREA:
            return (
                <textarea>Textarea</textarea>
            )

        default:
            break
    }
}

function Form(props) {
    const { inputs, buttons } = props

    const { handleSubmit, error } = useForm(inputs, () => { console.log('Form submit handler callback goes here') })

    const onSubmit = (e) => {
        e.preventDefault()
        handleSubmit()
    }

    return (
        <form className='form-body' onSubmit={onSubmit}>
            {inputs.map((input, key) =>
                <SwitchRender error={error} input={input} key={key} />
            )}
            {buttons.map((button, key) =>
                <div className={'button-wrapper'} key={key}>
                    {button.component}
                </div>
            )}
        </form>
    )
}

export default Form