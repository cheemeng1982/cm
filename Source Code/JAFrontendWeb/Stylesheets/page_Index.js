// not animated collapse/expand
function togglePannelStatus(content)
{
    var expand = (content.style.display=="none");
    content.style.display = (expand ? "block" : "none");
}

// current animated collapsible panel content
var currentContent = null;

function togglePannelAnimatedStatus(content, interval, step, panelIndex)
{
    // wait for another animated expand/collapse action to end
    if (currentContent==null)
    {
        currentContent = content;
        var expand = (content.style.display=="none");
        if (expand)
        {
            content.style.display = "block";
            setToggleStateMemory(panelIndex,1);
        }
        else
        {
            setToggleStateMemory(panelIndex,0);
        }
        
        var max_height = content.offsetHeight;

        var step_height = step + (expand ? 0 : -max_height);
                
        // schedule first animated collapse/expand event
        content.style.height = Math.abs(step_height) + "px";
        setTimeout("togglePannelAnimatingStatusProgress("
            + interval + "," + step
            + "," + max_height + "," + step_height + ")", interval);
    }
}

function togglePannelAnimatingStatusProgress(interval,
    step, max_height, step_height)
{
    var step_height_abs = Math.abs(step_height);

    // schedule next animated collapse/expand event
    if (step_height_abs>=step && step_height_abs<=(max_height-step))
    {
        step_height += step;
        currentContent.style.height = Math.abs(step_height) + "px";
        setTimeout("togglePannelAnimatingStatusProgress("
            + interval + "," + step
            + "," + max_height + "," + step_height + ")", interval);
    }
    // animated expand/collapse done
    else
    {
        if (step_height_abs<step)
            currentContent.style.display = "none";
        currentContent.style.height = "";
        currentContent = null;
    }
}

function setToggleStateMemory(panelIndex,value)
{
    if(hdTogglePanel)
    {
        var reconstructValue = '';
        var arrValues = hdTogglePanel.value.split(',');
        for(i = 1; i < arrValues.length + 1; i++)
        {
            if(i == panelIndex)
                reconstructValue += value + ',';
            else
                reconstructValue += arrValues[i - 1] + ',';
        }
        hdTogglePanel.value = reconstructValue.substring(0, reconstructValue.length - 1);
    }
}

function setInitToggleStatePostback(arrValues)
{
    var positionIndex = 1;
    for(i=1; i < arrValues.length + 1; i++)
    {
        if(arrValues[i-1] == 0)
        {
            userTogglePanel(positionIndex);
        }
        positionIndex += 1;
    }
}

function userTogglePanel(panelIndex)
{
    switch(panelIndex)
    {
        case 1:
            togglePannelStatus(document.getElementById('contentBookCat'));
            break;
        case 2:
            togglePannelStatus(document.getElementById('contentBookAuthor'));
            break;
        case 3:
            togglePannelStatus(document.getElementById('contentBookPublisher'));
            break;
        case 4:
            togglePannelStatus(document.getElementById('contentBookType'));
            break;
    }
}
