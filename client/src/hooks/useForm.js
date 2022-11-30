import { useCallback, useEffect, useState } from "react"

export default function useForm(inputs = []) {

    const [correct, setCorrect] = useState(false)
    const [error, setError] = useState([{}])

    const checkRequired = useCallback(() => {
        setError([])
        for (let i = 0; i < inputs.length; i++) {
            if (inputs[i].required && inputs[i].state === '') {
                setError(prev => [...prev, { field: inputs[i].name, message: `Field ${inputs[i].name} is required` }])
            }
        }
    }, [inputs])

    useEffect(() => {
        checkRequired()
    }, [inputs, checkRequired])

    useEffect(() => {
        setCorrect(error.length === 0)
    }, [error])

    const handleSubmit = () => {
        checkRequired()
    }

    return { handleSubmit, correct }
}