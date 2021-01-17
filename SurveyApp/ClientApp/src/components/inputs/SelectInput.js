import React from 'react'

export const SelectInput = props => {
    const { object } = props;

    return <select name={object.name} className={props.className} multiple={object.multiple}>
        <option hidden value>Select an option</option>
        {object.answers.map((data, index) => {
            return <option
                value={data.name}
                id={`${object.name}-${index}`}
                className={`form-check ${props.optionClassName}`}
                key={`${object.type}-${index}`}>
                {data.name}
            </option>
        })}

    </select>

}