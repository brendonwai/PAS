using System;
using System.Collections;

public struct Question{
	public string shape;
	public string color;
	public string quantity;
	public double creationRatio;
}

public class QuestionGenerator{
	private static string[] quantities = {"more","less"};
	private static string[] colors = {"blue","red","green","purple","yellow"};
	private static string[] shapes = {"circle","square","triangle"};

	public Question createQuestion(Question question, string shape, string color, string quantity, double ratio){
		question.shape = shape;
		question.color = color;
		question.quantity = quantity;
		question.creationRatio = ratio;
		return question;
	}
	// Returns the question and the win parameters, given some number of function parameters based on the difficulty.
	// The returns a question's indexs for a predefined array in the form <question, color, shape, side,ratio>.
	public Question getQuestion(int level) {
		System.Random r = new System.Random();
		string randomColor = null;
		string randomShape = null;
		string randomQuantity;
		double ratio = 1 / (1 + Math.Pow (Math.E, (level + 6) / 10)) + 0.5;		
		if (level < 4) {
			randomQuantity = quantities [r.Next(quantities.Length)];
			return createQuestion (new Question (), randomShape, randomColor, randomQuantity, ratio);
		} else if (level < 7) {
			randomQuantity = quantities [r.Next (quantities.Length)];
			switch (r.Next (2)) {
			case 0:
				randomShape = shapes [r.Next (shapes.Length)]; 
				return createQuestion (new Question (), randomShape, randomColor, randomQuantity, ratio);
			case 1:
				randomColor = colors [r.Next (colors.Length)]; 
				return createQuestion (new Question (), randomShape, randomColor, randomQuantity, ratio);

			}
		} else {
			randomQuantity = quantities [r.Next (quantities.Length)];
			randomShape = shapes [r.Next (shapes.Length)];
			randomColor = colors [r.Next (colors.Length)]; 
		}
		return createQuestion (new Question (), randomShape, randomColor, randomQuantity, ratio);
	} 
}
