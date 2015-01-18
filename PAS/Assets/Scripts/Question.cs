using System;
using System.Collections;

public struct Question{
	public int shape;
	public int color;
	public int quantity;
	public double creationRatio;
}

public class QuestionGenerator{
	private static int[] quantities = {0,1};
	private static int[] colors = {0,1,2,3,4,5};
	private static int[] shapes = {0,1,2,3};

	public Question createQuestion(Question question, int shape, int color, int quantity, double ratio){
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
		int randomColor = 0;
		int randomShape = 0;
		int randomQuantity = 0;
		double ratio = (50+level)/100;		
		if (level < 4) {
			randomQuantity = quantities [r.Next (2)];
			return createQuestion (new Question (), randomShape, randomColor, randomQuantity, ratio);
		} else if (level < 7) {
			randomQuantity = quantities [r.Next (2)];
			switch (r.Next (2)) {
			case 0:
				randomShape = shapes [r.Next (shapes.Length)]; 
				return createQuestion (new Question (), randomShape, randomColor, randomQuantity, ratio);
			case 1:
				randomColor = colors [r.Next (colors.Length)]; 
				return createQuestion (new Question (), randomShape, randomColor, randomQuantity, ratio);

			}
		} else {
			randomQuantity = quantities [r.Next (2)];
			randomShape = shapes [r.Next (shapes.Length)];
			randomColor = colors [r.Next (colors.Length)]; 
		}
		return createQuestion (new Question (), randomShape, randomColor, randomQuantity, ratio);
	} 
}
