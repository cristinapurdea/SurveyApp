import React from 'react'

export const RadioInput = props => {
    const { object } = props;
    return <div className={props.className}>
        {object.answers.map((data, index) => {
            return <div className={`form-check ${props.optionClassName}`}

                key={`${object.type}-${index}`}>

                <input
                    className='form-check-input'
                    type={object.type}
                    required={props.required}
                    value={data.name}
                    name={object.name}
                    id={`${object.name}-${index}`}
                />
                <label
                    className='form-check-label'

                    htmlFor={`${object.name}-${index}`}>
                    {data.name}
                </label>

            </div>
        })}

    </div>
}