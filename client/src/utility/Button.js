import React from 'react'

function Button(props) {
    const { type, text, action, className } = props
    return (
        <button type={type? type : 'button'} onClick={action} className={className}>
            {text}
        </button>
    )
}

export default Button