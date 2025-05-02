function Footer() {
  return (
    <footer className="w-full bg-[#E6E6E6] py-8 px-4 grid grid-cols-1 md:grid-cols-3 text-center">
      <div className="flex flex-col items-center justify-center gap-2">
        <p className="text-4xl font-bold">Tim Kuo Project</p>
        <a
          className="text-2xl text-blue-600 hover:underline"
          href="https://github.com/TimKuo0927"
          target="_blank"
          rel="noopener noreferrer"
        >
          GitHub
        </a>
      </div>

      <div className="flex flex-col items-center justify-center">
        <p className="text-lg">Contact Email:</p>
        <p className="text-lg">tim.kuo.yt@gmail.com</p>
      </div>

      <div className="flex items-center justify-center">
        <p className="text-sm text-gray-600">© 2025 Tim Kuo. All rights reserved.</p>
      </div>
    </footer>
  );
}

export default Footer;
