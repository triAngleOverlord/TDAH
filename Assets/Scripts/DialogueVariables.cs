using Ink.Runtime;
using System.Collections.Generic;
using UnityEngine;

public class DialogueVariables
{
    private Dictionary<string, Ink.Runtime.Object> variables;

    public DialogueVariables(TextAsset loadGlobalsJSON) 
    {
        Story globalVariablesStory = new Story(loadGlobalsJSON.text);

        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach(string name in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value= globalVariablesStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            Debug.Log("Added " + name+ " with " + value);
        }
    }
    public void StartListening(Story story) 
    {
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChange;
    }
    public void StopListening(Story story) 
    {
        story.variablesState.variableChangedEvent -= VariableChange;
    }
    private void VariableChange (string name, Ink.Runtime.Object value)
    {
        //Debug.Log("Variable changed :" + name + "=" +  value);  
        if(variables.ContainsKey(name))
        {
            variables.Remove(name);
            variables.Add(name, value);
        }
    }

    private void VariablesToStory(Story story)
    {
        foreach(KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}
