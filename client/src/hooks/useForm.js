import { useState, useEffect } from "react"
import { INPUT_TYPES } from "../constants/inputs"

export default function useForm(inputs = [{}], submitCallback) {

    /**
     * ----------------- useForm -----------------
     * 
     * Custom hook to validate forms:
     *  - takes input fields array and callback function ( which will run after form has been successfully validated )
     *  - validates multiple fields in real time (as the user is typing)
     *  - inputs array should contain listed key-value pairs to fully benefit from this hook
     *
     */

    /**
     * 
     * ----------------- inputs array -----------------
     *  - array of objects with key-value pairs
     * 
     * [{
     *  name: 'field name',
     *  type: INPUT_TYPES.FIELD_TYPE
     *  required: true / false,
     *  className: '',
     *  ref: useRef()
     * }]
     * 
     */

    const [submit, setSubmit] = useState(false)
    const [error, setError] = useState([{}])

    // Compare 'password' field with 'confirm password' field (if exists)
    const checkPassword = () => {
        let passwordField = inputs.find(input => input.name === 'password')
        let confirmPasswordField = inputs.find(input => input.name === 'confirm-password')

        if (confirmPasswordField) {
            let password = passwordField.ref.current.value
            let confirmPassword = confirmPasswordField.ref.current.value

            if (password.length < 8) {
                setError(prev => [...prev, {
                    field: passwordField['name'],
                    message: 'Password should be at least 8 characters long'
                }])

            } else {
                if (confirmPassword !== password) {
                    setError(prev => [...prev,
                    {
                        field: passwordField['name'],
                        message: 'Those passwords didn\'t match'
                    },
                    {
                        field: confirmPasswordField['name'],
                        message: 'Those passwords didn\'t match'
                    }
                    ])
                }
            }
        }
    }

    // Validate email field if exists in inputs array
    const checkEmail = () => {
        // Find error field and validate its value
        let emailInputField = inputs.find(input => input.type === INPUT_TYPES.EMAIL)
        if (emailInputField) {
            if (!/^[a-zA-Z0-9]+@(?:[a-zA-Z0-9]+\.)+[A-Za-z]+$/.test(emailInputField.ref.current.value)) {
                // Email not valid -> setError
                setError(prev => [...prev, {
                    field: emailInputField['name'],
                    message: `Invalid email address`
                }])
            }
        }
    }

    // Check if every field marked as 'required' is filled
    const checkRequired = () => {
        setError([])
        for (let i = 0; i < inputs.length; i++) {
            if (inputs[i].required && inputs[i].ref.current.value === '') {
                if (inputs[i].name === 'confirm-password') {
                    setError(prev => [...prev, {
                        field: inputs[i].name,
                        message: ''
                    }])

                } else {
                    setError(prev => [...prev, {
                        field: inputs[i].name,
                        message: `Field ${inputs[i].name} is required`
                    }])
                }
            }
        }
    }

    const validateForm = () => {
        checkRequired()
        checkEmail()
        checkPassword()
        setSubmit(true)
    }

    const handleSubmit = () => {
        if (!submit) { validateForm() }
    }

    useEffect(() => {
        if (submit) {
            if (error.length) {
                // Some fields have not been filled correctly
            } else {
                // All good - form filled correctly
                submitCallback()
            }
        }

        return () => {
            setSubmit(false)
        }
    }, [submit, error, submitCallback])

    return { handleSubmit, error }
}