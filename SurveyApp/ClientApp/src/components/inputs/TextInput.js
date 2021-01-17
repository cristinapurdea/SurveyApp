import React from 'react'

import { OnChange } from '../hooks/onChange'

export const TextInput = props => {
    const { value, handleChange } = OnChange(props.defaultValue, props.triggerCallback);
    const inputType = props.type || 'text';
    const inputProps = {
        className: props.className ? props.className : 'form-control',
        onChange: handleChange,
        required: props.required,
        value: value,
        type: inputType,
        placeholder: 'You can type here...',
        name: props.name ? props.name : `${inputType}_${props.key}`
    }
    return inputType === 'textarea' ?
        <textarea {...inputProps} /> :
        <input {...inputProps} />
}