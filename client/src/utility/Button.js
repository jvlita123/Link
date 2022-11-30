import React from 'react'

function Button(props) {
    const { text, action, className } = props
    return (
        <button onClick={action} className={className}>
            {text}
        </button>
    )
}

export default Button