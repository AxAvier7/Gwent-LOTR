public class ErrorRekon{
    public ErrorRekon(CodeLocation location, ErrorID code, string arg){
        this.Code = code;
        this.Arg = arg;
        Location = location;
    }

    public ErrorID Code{get;}
    public string Arg{get;}
    public CodeLocation Location{get;}

    public enum ErrorID{
        None,
        Expected,
        Invalid,
        Unknown,
    }
}