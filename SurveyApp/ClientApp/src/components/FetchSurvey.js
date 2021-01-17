import React, { Component } from 'react';
import { RadioInput } from './inputs/RadioInput';
import { SelectInput } from './inputs/SelectInput';
import { TextInput } from './inputs/TextInput';

export class FetchSurvey extends Component {
    constructor(props) {
        super(props);
        this.state = {
            page: 1,
            survey: {},
            loadedQuestions: [],
            surveyValues: [],
            isFinalPage: false,
            loading: true
        };
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    componentDidMount() {
        this.populateSurveyData();
    }

    triggerBackendUpdate() {
        console.log(this.state.surveyValues);
        alert("Thank you");
        // assume backend updated    

        this.setState({ page: 1, surveyValues: {}, isFinalPage: false });
    };

    handleSubmit(event) {
        event.preventDefault();
        event.persist();
        for (let formInput of event.target.elements) {
            
            this.state.surveyValues[formInput.name] = formInput.value;

            if (formInput.type === 'select' && formInput.multiple) {
                const selected = [].filter.call(formInput.options, option => option.selected);
                const values = selected.map(option => option.value);
                this.state.surveyValues[formInput.name] = values;
            }

            if (formInput.checked) {
                this.state.surveyValues[formInput.name] = formInput.value;
            }

        }

        const nextPage = this.state.page + 1;
        const questions = this.state.loadedQuestions ? this.state.loadedQuestions.filter(question => question.page === nextPage) : [];

        if (this.state.isFinalPage) {
            this.triggerBackendUpdate();
        } else {
            if (questions.length === 0) {
                this.setState({
                    isFinalPage: true
                });
            } else {
                this.setState({
                    page: nextPage
                });
            }
        }
    }

    renderSurvey(survey) {

        const questions = this.state.loadedQuestions ? this.state.loadedQuestions.filter(question => question.page === this.state.page) : [];

        return (
            <form onSubmit={this.handleSubmit}>
                <p>{survey.name}</p>
                <p>{survey.description}</p>
                {
                    questions.map((question, index) => {
                        const className = 'form-control mb-2 animated fadeIn';
                        const inputKey = `input-${index}-${this.state.page}`;

                        return (<React.Fragment>
                            <p><strong>{question.order}. </strong>{question.name}</p>
                            {
                                (question.type === 'radio' || question.type === 'checkbox') ?
                                    <RadioInput
                                        object={question}
                                        key={inputKey}
                                        className={className}
                                        {...question}

                                    />

                                    :

                                    (question.type === 'select') ?
                                        <SelectInput
                                            className={className}
                                            object={question}
                                            key={inputKey}
                                            {...question}
                                        />

                                        :

                                        <TextInput
                                            className={className}
                                            key={inputKey}
                                            {...question}
                                        />

                            } </React.Fragment>)
                        })
                    }   

                {
                    this.state.isFinalPage === true &&
                    <p>Are you finished?</p>
                }
                <button
                    name='save_btn'
                    type='submit'
                    className='btn btn-primary my-5 animated fadeIn delay-2s'>{this.state.isFinalPage === true ? "Save" : "Continue"}</button>

            </form>

        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderSurvey(this.state.survey);

        return (
            <div>
                <h1 id="tabelLabel" >Survey app</h1>
                <p>Please answer the following questions.</p>
                {contents}
            </div>
        );
    }

    async populateSurveyData() {
        const response = await fetch('survey');
        const data = await response.json();
        this.setState({ survey: data, loadedQuestions: data.questions, loading: false });
    }
}
