import React, { useEffect, useRef, useState } from 'react'
import { INPUT_ELEMENTS } from '../constants/inputs'
import useForm from '../hooks/useForm'

function Input(props) {
    const { input } = props
    const [focus, setFocus] = useState(false)
    const inputElement = useRef()

    useEffect(() => {
        if (focus) inputElement.current.focus()
    }, [focus])

    return (
        <div onClick={() => setFocus(true)} className={'input-wrapper full-width ' + input.className + (focus ? ' focus' : '')}>
            <input
                name={input.name}
                defaultValue={input.state}
                onChange={(e) => input.setState(e.target.value)}
                ref={inputElement}
                onFocus={() => setFocus(true)}
                onBlur={() => setFocus(false)}
                type={input.type}
                placeholder={input.placeholder} />
        </div>
    )
}

function SwitchRender(props) {
    const { input } = props

    switch (input.inputElement) {
        case INPUT_ELEMENTS.INPUT:
            return (
                <Input input={input} />
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

    const { handleSubmit, correct } = useForm(inputs)

    const onSubmit = (e) => {
        e.preventDefault()
        handleSubmit()
    }

    return (
        <form className='form-body' onSubmit={(e) => onSubmit(e)}>
            {inputs.map((input, key) =>
                <SwitchRender input={input} key={key} />
            )}
            {buttons.map((button, key) =>
                <div className={correct ? 'button-wrapper' : 'button-wrapper disabled'} key={key}>
                    {button.component}
                </div>
            )}
        </form>
    )
}

export default Form