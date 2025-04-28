interface ButtonProps {
  label: string;
  variant?: 'primary' | 'secondary' | 'danger' | 'outline';
  onClick?: () => void;
  disabled?: boolean;
}

function Button({ label, variant = 'primary', onClick, disabled = false }: ButtonProps) {
    const baseClasses = 'font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline';
  
    let variantClass = '';
  
    if (variant === 'primary') variantClass = "bg-blue-500 hover:bg-blue-700 text-white";
    if (variant === 'secondary') variantClass = 'bg-gray-500 hover:bg-gray-700 text-white';
    if (variant === 'danger') variantClass = 'bg-red-500 hover:bg-red-700 text-white';
    if (variant === 'outline') variantClass = 'bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white hover:border-transparent';
  
    return (
      <button
        type="button"
        className={`${baseClasses} ${variantClass} ${disabled ? 'opacity-50 cursor-not-allowed' : ''}`}
        onClick={onClick}
        disabled={disabled}
      >
        {label}
      </button>
    );
  }

export default Button;
