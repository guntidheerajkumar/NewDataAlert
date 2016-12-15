# NewDataAlert

Twitter Style Animated New Data Alert

###Usage
```
NewAlert alert = new NewAlert();
alert.ShowMessage("New Tweets", this.View);
alert.Process += (sender, e) => {
	this.View.BackgroundColor = UIColor.Yellow;
};
```


###Output
![](https://github.com/guntidheerajkumar/NewDataAlert/blob/master/Output.gif)
