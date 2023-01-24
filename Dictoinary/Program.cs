namespace Dictoinary;

public class BracketValidator
{
    private static readonly Dictionary<char, char> mapping = new Dictionary<char, char>()
    {
        ['{'] = '}',
        ['('] = ')',
        ['['] = ']',
        ['1'] = ')',
        ['a'] = 'A'
    };

    public static bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            if (mapping.ContainsKey(s[i]))
            {
                stack.Push(s[i]);
            }
            else
            {
                if (stack.Count == 0)
                    return false;
                char ch = stack.Pop();

                if (s[i] != mapping[ch])
                    return false;
            }
        }
        return stack.Count == 0;
    }
    public static bool IsValid1(string s)
    {
        Stack<char> stack = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(' || s[i] == '[' || s[i] == '{')
            {
                stack.Push(s[i]);
            }
            else
            {
                if (stack.Count == 0) return false;
                char ch = stack.Pop();

                if (s[i] == ')') 
                    if (ch != '(') return false;
            
                if (s[i] == '}') 
                    if (ch !='{') return false;
            
                if (s[i] == ']') 
                    if (ch != '[') return false;
            }
        }
        return stack.Count == 0;
    }
    public static bool IsValid2(string s)
    {
        Stack<char> stack = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(' || s[i] == '{' || s[i] == '[')
            {
                stack.Push(s[i]);
            }
            else
            {
                if (stack.Count == 0) return false;
                char ch = stack.Pop();
                
                if (s[i] == ')')
                    if (ch != '(') return false;
            }
        }
        return stack.Count == 0;
    }
    
    public static void Main(string[] args)
    {
        BracketValidator validator = new BracketValidator(); 
        IsValid("([)");
        IsValid1("([])");
        IsValid2("([]))");
    }
}